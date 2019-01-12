using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;

namespace Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts
{
    public class CheckoutedLineItem : IHaveId <Guid>
    {
        public CheckoutedLineItem()
        {
            
        }
   
        public Guid Id { get; set; }
        /// <summary>
        /// if this is null then it means that this item added by admin that means it's an extra item which optionally added
        /// </summary>
        public Guid? FormRequestLineItemId { get; set; }
        public TrackingState State { get; set; }
        public Commodity Commodity { get; set; }
        public int CommodityId { get; set; }
        public int RequiredAmount { get; set; }
        public int FinalPurchaseCount { get; set; }

        public int CommodityPurchaseBid => RequiredAmount > Commodity.AvailableAmount
            ? RequiredAmount - Commodity.AvailableAmount
            : 0;


        public override string ToString()
        {
            return
                $"{Commodity.Title} available {Commodity.AvailableAmount} {Commodity.Unit.Title} ------ request for {RequiredAmount}";
        }
    }
}