using System;

namespace Zafaran.WareHouse.Core.Dtos.CommodityRequestForms
{
    public class CommodityRequestFormLineItemViewModel
    {
        public int Amount { get; set; }
        public int CommodityId { get; set; }
        public Guid Id { get; set; }
    }
}