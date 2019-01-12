using System;

namespace Zafaran.WareHouse.Core.Entities.Aggregates.InventoryEntryForms
{
    public  class EntryFormLineItem:IHaveId<Guid>
    {
        public Guid Id { get; set; }
        public int CommodityId { get; set; }
        public int Amount { get; set; }
    }
}