using System.Reflection.Metadata;
using System.Security.Cryptography;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;

namespace Zafaran.Warehouse.Core.Events
{
    public interface IHandler<T> where T: IDomainEvent
    {
        void  Handle(T arg);
    }
}