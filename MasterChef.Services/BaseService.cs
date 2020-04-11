using MasterChef.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace MasterChef.Services
{
    public class BaseService<T> : IService<T>
    {
        //private readonly BaseRepository<T> repository = new BaseRepository<T>();

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            // repository.Delete(id);
        }

        public IList<T> Get()
        {
            throw new System.NotImplementedException();
        }

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            //  return repository.Select(id);

            throw new NotImplementedException();
        }

        public T Post(T obj)
        {
            // Validate(obj, Activator.CreateInstance());

            //  repository.Insert(obj);
            //  return obj;

            throw new NotImplementedException();
        }

        public T Post<V>(T obj)
        {
            throw new NotImplementedException();
        }

        public T Put(T obj)
        {
            // Validate(obj, Activator.CreateInstance<V>());

            // repository.Update(obj);
            return obj;
        }

        public T Put<V>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}