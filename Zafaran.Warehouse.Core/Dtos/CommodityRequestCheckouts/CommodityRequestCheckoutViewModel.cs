using System;
using System.Collections.Generic;

namespace Zafaran.Warehouse.Core.Dtos.CommodityRequestCheckouts
{
    public class CommodityRequestCheckoutViewModel
    {
        public Guid Id { get; set; }
        public List<CheckoutedLineItemViewModel> LineItems { get; set; }
    }

    public class CheckoutedLineItemViewModel
    {
        public Guid Id { get; set; }
        public int FinalPurchaseCount { get; set; }
        public int RequiredAmount { get; set; }
        public int CommodityPurchaseBid { get; set; }
        public Guid? FormRequestLineItemId { get; set; }
        public int CommodityId { get; set; }
        public string CommodityTitle { get; set; }
        public int CommodityAvailableAmount { get; set; }
        public string CommodityUnitTitle { get; set; }
    }
}