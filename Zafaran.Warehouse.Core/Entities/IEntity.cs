using System;

namespace Zafaran.WareHouse.Core.Entities
{
    public interface IEntity<TKey>:IHaveId<TKey> where TKey : struct
    {
        TKey Id { get; set; }
    }
}