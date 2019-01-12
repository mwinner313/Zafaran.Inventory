using System;
using System.Collections.Generic;
using System.Linq;
using Zafaran.WareHouse.Core.Dtos.CommodityRequestForms;

namespace Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms
{
    public class CommodityRequestForm : Entity<Guid>
    {
        public CommodityRequestForm(List<CommodityRequestFormLineItem> lineItems, int resturantId)
        {
            Id = Guid.NewGuid();
            _resturantId = resturantId;
            lineItems.ForEach(x => x.State = TrackingState.Added);
            LineItems = lineItems;
        }

        public CommodityRequestForm(Guid id, List<CommodityRequestFormLineItem> lineItems, int resturantId)
        {
            Id = id;
            _resturantId = resturantId;
            lineItems.ForEach(x => x.State = TrackingState.UnChanged);
            LineItems = lineItems.ToList();
        }

        public CommodityRequestForm()
        {
        }

       
        private CommodityRequestState _state;
        public CommodityRequestState State => _state;
        private int _resturantId;
        public int ResturantId => _resturantId;
        public ICollection<CommodityRequestFormLineItem> LineItems { get; private set; }

        public void UpdateItems(List<CommodityRequestFormLineItem> lineItems)
        {
            if (State == CommodityRequestState.Performed)
            {
                throw new InvalidOperationException("form has performed by inventory management");
            }

            foreach (var existing in LineItems)
            {
                var updated = lineItems.FirstOrDefault(x => x.Id == existing.Id);
                if (updated == null)
                {
                    existing.State = TrackingState.Deleted;
                    continue;
                }

                existing.Amount = updated.Amount;
                existing.CommodityId = updated.CommodityId;
                existing.State = TrackingState.Edited;
            }

            lineItems.Where(x => x.Id == default(Guid)).ToList().ForEach(x =>
            {
                x.Id = Guid.NewGuid();
                x.FormId = Id;
                x.State = TrackingState.Added;
                LineItems.Add(x);
            });
        }
    }
}