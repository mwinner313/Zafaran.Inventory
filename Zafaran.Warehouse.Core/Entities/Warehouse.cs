using System.Collections;
using System.Collections.Generic;

namespace Zafaran.WareHouse.Core.Entities
{
    public class Warehouse:Entity<int>
    {
        public string Title { get; set; }
        public  ICollection<CommidityWarehouseInventory> Inventories { get; private set; } 
    }
}