using Dapper;
using MasterChef.Domain.Entidades;
using MasterChef.Domain.Interfaces;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MasterChef.Infra.Data.Repository
{
    public sealed class CategoriaRepository : ICategoria<CategoriaDTO>
    {
        private readonly string driver = Factory.Conexao.Instance.GetConection();

        public IEnumerable<CategoriaDTO> ObterTodos(int codigo = 0, string nome = "")
        {
            List<CategoriaDTO> categorias = null;

            using (var Connection = new SQLiteConnection(driver))
            {
                var sql = $"SELECT ID, Titulo, Descricao FROM CATEGORIAS ";

                if (!string.IsNullOrEmpty(nome))
                    sql += $"WHERE Titulo LIKE '%'|| @Pesquisa ||'%' ";

                if (codigo > 0)
                    sql += $"WHERE ID = @Codigo ";

                sql += $"ORDER BY (ID)";

                categorias = Connection.Query<CategoriaDTO>(sql, new { Pesquisa = nome, Codigo = codigo }).AsList();
            }
            return categorias;
        }

        public CategoriaDTO Obter(int codigo)
        {
            CategoriaDTO categoria = null;

            using (var Connection = new SQLiteConnection(Factory.Conexao.Instance.GetConection()))
            {
                var sql = $"SELECT ID, Titulo, Descricao FROM CATEGORIAS ";
                sql += $"WHERE ID = @Codigo";

                categoria = Connection.QueryFirstOrDefault<CategoriaDTO>(sql, new { Codigo = codigo });
            }
            return categoria;
        }

        public bool Inserir(CategoriaDTO categoria)
        {
            bool result = false;

            using (var Connection = new SQLiteConnection(driver))
            {
                var sql = $"INSERT INTO CATEGORIAS (TITULO, DESCRICAO) VALUES " +
                          $"(@titulo, @descricao)";

                var parametros = new DynamicParameters();
                parametros.Add("titulo", categoria.Titulo);
                parametros.Add("descricao", categoria.Descricao);

                if (Connection.Execute(sql, parametros) > 0)
                    result = true;
            }
            return result;
        }

        public bool Atualizar(CategoriaDTO categoria)
        {
            bool result = false;

            using (var Connection = new SQLiteConnection(driver))
            {
                var sql = $"UPDATE CATEGORIAS SET TITULO = @titulo, DESCRICAO = @descricao WHERE ID = @id";

                var parametros = new DynamicParameters();
                parametros.Add("id", categoria.ID);
                parametros.Add("titulo", categoria.Titulo);
                parametros.Add("descricao", categoria.Descricao);

                if (Connection.Execute(sql, parametros) > 0)
                    result = true;
            }
            return result;
        }

        public bool Apagar(int id)
        {
            bool result = false;

            using (var Connection = new SQLiteConnection(driver))
            {
                var sql = $"DELETE FROM CATEGORIAS WHERE ID = @id";

                var parametros = new DynamicParameters();
                parametros.Add("id", id);

                if (Connection.Execute(sql, parametros) > 0)
                    result = true;
            }
            return result;
        }
    }
}