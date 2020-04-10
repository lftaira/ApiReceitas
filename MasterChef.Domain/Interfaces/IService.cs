using System.Collections.Generic;

namespace MasterChef.Domain.Interfaces
{
    public interface IService<T>
    {
        T Get(int id);

        IList<T> Get();

        T Post<V>(T obj);

        T Put<V>(T obj);

        void Delete(int id);
    }
}