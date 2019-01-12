namespace Zafaran.WareHouse.Core.Entities
{
    public interface IHaveId<TKey> where TKey : struct
    {
        TKey Id { get; set; }
    }
}