using MasterChef.Domain.Entidades;
using MasterChef.Domain.Interfaces;
using System.Collections.Generic;

namespace MasterChef.Services
{
    public sealed class CategoriaService : ICategoria<CategoriaDTO>
    {
        private readonly ICategoria<CategoriaDTO> repository = null;

        public CategoriaService()
        {
            repository = MasterChef.Infra.IoC.ServiceLocator.Instance.GetService<ICategoria<CategoriaDTO>>();
        }

        public CategoriaDTO Obter(int codigo = 0)
        {
            CategoriaDTO categoria = null;

            if (codigo > 0)
                categoria = repository.Obter(codigo);

            return categoria;
        }

        public IEnumerable<CategoriaDTO> ObterTodos(int codigo = 0, string nome = "")
        {
            return repository.ObterTodos(codigo, nome);
        }

        public CategoriaDTO Inserir(CategoriaDTO categoria)
        {
            return repository.Inserir(categoria);
        }

        public bool Atualizar(CategoriaDTO categoria)
        {
            return repository.Atualizar(categoria);
        }

        public bool Apagar(int id)
        {
            bool result = false;

            if (id > 0)
                result = repository.Apagar(id);

            return result;
        }
    }
}