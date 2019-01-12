using System;
using System.Collections.Generic;

namespace Zafaran.WareHouse.Core.Entities.Aggregates.InventoryEntryForms
{
    public class EntryForm : Entity<Guid>
    {
        public ICollection<EntryFormLineItem> LineItems { get; set; }
        public Guid Id { get; set; }
        public int InventoryId { get; set; }
    }
}