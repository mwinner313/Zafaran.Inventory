using System.ComponentModel.DataAnnotations;

namespace Zafaran.Warehouse.Core.Dtos.Warehouses
{
    public class WarehouseAddOrUpdateModel
    {
        [Required]
        public string Title { get; set; }
        public int Id { get; set; }
    }
}