using System;

namespace Zafaran.WareHouse.Core.Entities.Aggregates.CommodityReturnForms
{
    public  class CommodityReturnFormLineItem:IHaveId<Guid>
    {
        public Guid Id { get; set; }
        public int CommodityId { get; set; }
        public int Amount { get; set; }
    }
}