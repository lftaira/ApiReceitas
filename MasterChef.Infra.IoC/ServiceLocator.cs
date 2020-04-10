using MasterChef.Domain.Entidades;
using MasterChef.Domain.Interfaces;
using MasterChef.Infra.Data.Repository;
using MasterChef.Infra.IoC.Interface;
using System;
using System.Collections.Generic;

namespace MasterChef.Infra.IoC
{
    public sealed class ServiceLocator : IServiceLocator
    {
        private readonly IDictionary<object, object> services;

        private static ServiceLocator instance = null;

        private static readonly object padlock = new object();

        public static ServiceLocator Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new ServiceLocator();

                    return instance;
                }
            }
        }

        internal ServiceLocator()
        {
            services = new Dictionary<object, object>();

            this.services.Add(typeof(ICategoria<CategoriaDTO>), new CategoriaRepository());
            this.services.Add(typeof(IReceita<ReceitaDTO>), new ReceitaRepository());
        }

        public T GetService<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            }
            catch
            {
                throw new ApplicationException("O serviço solicitado não está registrado");
            }
        }
    }
}