using System;
using System.Collections.Generic;
using System.Linq;

namespace Zafaran.WareHouse.Core.Entities
{
    public class Commodity : Entity<int>
    {
        public ICollection<CommidityWarehouseInventory> Inventories { get; set; }
        public string Title { get; set; }
        public Unit Unit { get; set; }
        public int UnitId { get; set; }
        public string Code { get; set; }

        public int AvailableAmount
        {
            get
            {
                if (Inventories is null)
                    throw new InvalidOperationException("Inventories is null");
                return Inventories.Sum(x => x.Amount);
            }
        }
    }
}