using System;
using System.Collections.Generic;

namespace Zafaran.WareHouse.Core.Entities.Aggregates.CommodityReturnForms
{
    /// <summary>
    /// فرم بازگشت کالا به انبار
    /// </summary>
    
    public class CommidityReturnForm:Entity<Guid>
    {
        public CommidityReturnForm()
        {
        }
        public Guid Id { get; set; }
        public ICollection<CommodityReturnFormLineItem> LineItems { get; set; }
    }
}