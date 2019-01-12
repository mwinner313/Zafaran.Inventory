using System;
using System.Collections.Generic;

namespace Zafaran.WareHouse.Core.Dtos.CommodityRequestForms
{
    public class CommodityRequestFormViewModel
    {
        public Guid Id { get; set; }
        public int ResturantId { get; set; }
        public List<CommodityRequestFormLineItemViewModel> LineItems { get; set; }
    }
}