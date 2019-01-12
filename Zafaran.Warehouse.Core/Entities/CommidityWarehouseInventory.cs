namespace Zafaran.WareHouse.Core.Entities
{
    /// <summary>
    /// this class determines availability of a commodity with it's available amount in a specific warehouse
    /// </summary>
    public class CommidityWarehouseInventory:IEntity<int>
    {
        public Commodity Commodity { get; set; }
        public Warehouse Warehouse { get; set; }
        public int CommodityId { get; set; }
        public int WareHouseId { get; set; }
        public int Amount { get; set; }
        public int Id { get; set; }
    }
}