using System.ComponentModel.DataAnnotations;

namespace Zafaran.Warehouse.Core.Dtos.Commodities
{
    public class CommodityAddOrUpdateModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        public string Code { get; set; }
    }
}