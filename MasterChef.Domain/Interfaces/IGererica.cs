using System.Collections.Generic;

namespace MasterChef.Domain.Interfaces
{
    public interface IGenerica<T>
    {
        IEnumerable<T> ObterTodos(int codigo = 0, string nome = "");

        T Obter(int codigo = 0);

        bool Inserir(T objeto);

        bool Atualizar(T objeto);

        bool Apagar(int id);
    }
}