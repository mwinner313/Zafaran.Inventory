using System.Collections.Generic;

namespace Zafaran.WareHouse.Core.Contracts
{
    public class PagenatedList<T>
    {
        public List<T> Items{ get; set; }
        public int Total { get; set; }
    }
}