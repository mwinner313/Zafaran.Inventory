using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms
{
    public  class CommodityRequestFormLineItem:IHaveId<Guid>
    {
        
        public Guid Id { get; set; }
        public int CommodityId { get; set; }
        public Commodity Commodity { get; set; }
        public int Amount { get; set; }
        public TrackingState State { get; set; }
        public Guid FormId { get; set; }
    }
}