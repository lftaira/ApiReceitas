using MasterChef.Domain.Entidades;
using MasterChef.Domain.Interfaces;
using System.Collections.Generic;

namespace MasterChef.Services
{
    public sealed class ReceitaService : IReceita<ReceitaDTO>
    {
        private readonly IReceita<ReceitaDTO> repository = null;

        public ReceitaService()
        {
            repository = Infra.IoC.ServiceLocator.Instance.GetService<IReceita<ReceitaDTO>>();
        }

        public ReceitaDTO Obter(int codigo = 0)
        {
            ReceitaDTO receita = null;

            if (codigo > 0)
                receita = repository.Obter(codigo);

            return receita;
        }

        public IEnumerable<ReceitaDTO> ObterTodos(int codigo = 0, string nome = "")
        {
            return repository.ObterTodos(codigo, nome);
        }

        public ReceitaDTO Inserir(ReceitaDTO receita)
        {
            return repository.Inserir(receita);
        }

        public bool Atualizar(ReceitaDTO receita)
        {
            return repository.Atualizar(receita);
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