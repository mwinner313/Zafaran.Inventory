using System;

namespace Zafaran.Warehouse.Core.Dtos.CommodityRequestCheckouts
{
    public class CommodityRequestCheckoutQuery:BaseQuery
    {
        public DateTime? StartDate { get; set; } =DateTime.Today;
        public DateTime? EndDate { get; set; } = DateTime.Today.AddDays(1);
        public int? ResturantId { get; set; }
    }
}
