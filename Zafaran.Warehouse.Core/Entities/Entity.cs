using System;

namespace Zafaran.WareHouse.Core.Entities
{
    public class Entity<TKey>:IEntity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime CreatedOn { get; protected set; }=DateTime.Now;
    }
}