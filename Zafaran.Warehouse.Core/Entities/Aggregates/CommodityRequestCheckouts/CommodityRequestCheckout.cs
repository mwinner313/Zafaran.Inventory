using System;
using System.Collections.Generic;
using System.Linq;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;

namespace Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts
{
    public class CommodityRequestCheckout : Entity<Guid>
    {
        public CommodityRequestForm RequestForm { get; private set; }
        public List<CheckoutedLineItem> LineItems { get; private set; }
        private CheckoutState _state;
        public CheckoutState State => _state;

        public CommodityRequestCheckout(List<CheckoutedLineItem> lineItems, CommodityRequestForm requestForm)
        {
            RequestForm = requestForm;
            ValidateLineItems(lineItems);
            LineItems = lineItems;
            _state = CheckoutState.Pending;
        }

        public CommodityRequestCheckout(Guid id, List<CheckoutedLineItem> lineItems, CommodityRequestForm requestForm,
            CheckoutState state)
        {
            Id = id;
            RequestForm = requestForm;
            ValidateLineItems(lineItems);
            LineItems = lineItems;
            _state = state;
        }

       
        public CommodityRequestCheckout()
        {
        }
        private  void ValidateLineItems(List<CheckoutedLineItem> lineItems)
        {
            CheckDoesIncludesAllFormLineItems(lineItems);
            CheckAllItemsHasSatisfyingPurchaseAmount(lineItems);
        }

        private  void CheckAllItemsHasSatisfyingPurchaseAmount(List<CheckoutedLineItem> lineItems)
        {
            lineItems.ForEach(x =>
            {
                if (x.CommodityPurchaseBid > x.FinalPurchaseCount)
                    throw new InvalidOperationException(
                        $"{nameof(x.FinalPurchaseCount)} should not be less than {nameof(x.CommodityPurchaseBid)} in {x}");
            });
        }
        private void CheckDoesIncludesAllFormLineItems(List<CheckoutedLineItem> lineItems)
        {
            var lineItmesInFormIds = RequestForm.LineItems.Select(x => x.Id).ToList();
            var newLineItemIds = lineItems.Where(x => x.FormRequestLineItemId.HasValue).Select(x => x.FormRequestLineItemId).ToList();
            if (lineItmesInFormIds.Any(x => !newLineItemIds.Contains(x)))
                throw new InvalidOperationException("one of line items in form request is missing");
        }
        
        public static CommodityRequestCheckout Create(CommodityRequestForm form)
        {
            var lineItems = new List<CheckoutedLineItem>();
            foreach (var requestLineItem in form.LineItems)
            {
                var lineItem = new CheckoutedLineItem()
                {
                    Commodity = requestLineItem.Commodity,
                    FormRequestLineItemId = requestLineItem.Id,
                    RequiredAmount = requestLineItem.Amount
                };
                lineItems.Add(lineItem);
            }

            return new CommodityRequestCheckout(form.Id, lineItems, form, CheckoutState.Pending);
        }

        public void UpdateItems(List<CheckoutedLineItem> lineItems)
        {
            ValidateLineItems(lineItems);
            foreach (var lineItem in lineItems)
            {
                var existing = LineItems.FirstOrDefault(x => x.Id == lineItem.Id);
                if (existing == null)
                {
                    lineItem.State = TrackingState.Added;
                    LineItems.Add(lineItem);
                    continue;
                }

                existing.FinalPurchaseCount = lineItem.FinalPurchaseCount;
                existing.State = TrackingState.Edited;
            }

            foreach (var optionallyAdded in LineItems.Where(x=>!x.FormRequestLineItemId.HasValue).ToList())
            {
                if (lineItems.All(x => x.Id != optionallyAdded.Id))
                    optionallyAdded.State = TrackingState.Deleted;
            }
        }
        
        public void UpdateItemsByForm(CommodityRequestForm form)
        {
            UpdateItemsCreatedFromEntireForm(form);
            AddNewAddedItemsFromForm(form);
            HandleFinalPurchaseCount();
        }

        private void HandleFinalPurchaseCount()
        {
            LineItems.ForEach(x =>
            {
                if (x.FinalPurchaseCount < x.RequiredAmount)
                    x.FinalPurchaseCount = x.CommodityPurchaseBid;
            });
        }
        private void AddNewAddedItemsFromForm(CommodityRequestForm form)
        {
            foreach (var formLineItem in form.LineItems.Where(x => x.Id != Guid.Empty).ToList())
            {
                var item = new CheckoutedLineItem
                {
                    RequiredAmount = formLineItem.Amount,
                    FormRequestLineItemId = formLineItem.Id,
                    Commodity = formLineItem.Commodity,
                    State = TrackingState.Added
                };
                this.LineItems.Add(item);
            }
        }
        private void UpdateItemsCreatedFromEntireForm(CommodityRequestForm form)
        {
            var createdFromFormItems = LineItems.Where(x => x.FormRequestLineItemId.HasValue).ToList();
            foreach (var checkoutedLineItem in createdFromFormItems)
            {
                var updated = form.LineItems.FirstOrDefault(x => x.Id == checkoutedLineItem.FormRequestLineItemId);
                if (updated == null)
                {
                    checkoutedLineItem.State = TrackingState.Deleted;
                    continue;
                }
                checkoutedLineItem.Commodity = updated.Commodity;
                checkoutedLineItem.RequiredAmount = updated.Amount;
                checkoutedLineItem.FinalPurchaseCount = checkoutedLineItem.CommodityPurchaseBid;
                checkoutedLineItem.State = TrackingState.Edited;
            }
        }
    }
}