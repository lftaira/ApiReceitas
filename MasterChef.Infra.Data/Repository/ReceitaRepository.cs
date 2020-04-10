using Dapper;
using MasterChef.Domain.Entidades;
using MasterChef.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MasterChef.Infra.Data.Repository
{
    public sealed class ReceitaRepository : IReceita<ReceitaDTO>
    {
        private readonly string driver = Factory.Conexao.Instance.GetConection();

        public IEnumerable<ReceitaDTO> ObterTodos(int codigo = 0, string nome = "")
        {
            List<ReceitaDTO> receitas = null;

            using (var Connection = new SQLiteConnection(driver))
            {
                var sql = $"SELECT R.ID, R.TITULO, R.DESCRICAO, INGREDIENTES, MODODEPREPARO, IMAGEM, TAGS, CATEGORIAID ID, C.TITULO,C.DESCRICAO " +
                          $"FROM RECEITAS R " +
                          $"INNER JOIN CATEGORIAS C ON R.CATEGORIAID = C.ID ";

                if (!string.IsNullOrEmpty(nome))
                    sql += $"WHERE Titulo LIKE '%'|| {nome} ||'%' ";

                if (codigo > 0)
                    sql += $"WHERE R.ID = {codigo} ";

                sql += $"ORDER BY (R.ID)";

                receitas = Connection.Query<ReceitaDTO>(sql, new[] { typeof(ReceitaDTO), typeof(CategoriaDTO) },
                   objects =>
                   {
                       var receitaModel = objects[0] as ReceitaDTO;
                       var categoriaModel = objects[1] as CategoriaDTO;

                       receitaModel.Categoria = categoriaModel;

                       return receitaModel;
                   },
                   splitOn: "ID, ID").AsList();
            }
            return receitas;
        }

        public ReceitaDTO Obter(int codigo)
        {
            ReceitaDTO receita = null;

            using (var Connection = new SQLiteConnection(driver))
            {
                var sql = $"SELECT R.ID, R.TITULO, R.DESCRICAO, INGREDIENTES, MODODEPREPARO, IMAGEM, TAGS, CATEGORIAID ID, C.TITULO, C.DESCRICAO " +
                          $"FROM RECEITAS R " +
                          $"INNER JOIN CATEGORIAS C ON R.CATEGORIAID = C.ID " +
                          $"WHERE R.ID = {codigo}";

                receita = Connection.Query<ReceitaDTO>(sql, new[] { typeof(ReceitaDTO), typeof(CategoriaDTO) },
                   objects =>
                   {
                       var receitaModel = objects[0] as ReceitaDTO;
                       var categoriaModel = objects[1] as CategoriaDTO;

                       receitaModel.Categoria = categoriaModel;

                       return receitaModel;
                   },
                   splitOn: "ID, ID").First();
            }
            return receita;
        }

        public ReceitaDTO Inserir(ReceitaDTO receita)
        {
            using (var Connection = new SQLiteConnection(driver))
            {
                var sql = $"INSERT INTO RECEITAS (TITULO,DESCRICAO,INGREDIENTES,MODODEPREPARO,TAGS,CATEGORIAID)" +
                          $" VALUES " +
                          $"(@titulo, @descricao, @ingredientes,@mododepreparo,@tags, @categoriaid); ";

                var parametros = new DynamicParameters();
                parametros.Add("titulo", receita.Titulo);
                parametros.Add("descricao", receita.Descricao);
                parametros.Add("ingredientes", receita.Ingredientes);
                parametros.Add("mododepreparo", receita.ModoDePreparo);
                parametros.Add("tags", receita.Tags);
                parametros.Add("categoriaid", receita.Categoria.ID);

                sql += $"SELECT LAST_INSERT_ROWID() ID;";

                receita.ID = (Int64)Connection.ExecuteScalar(sql, parametros);
            }
            return receita;
        }

        public bool Atualizar(ReceitaDTO receita)
        {
            bool result = false;

            using (var Connection = new SQLiteConnection(driver))
            {
                var sql = $"UPDATE RECEITAS SET TITULO = @titulo, " +
                          $"DESCRICAO = @descricao, " +
                          $"INGREDIENTES = @ingredientes, " +
                          $"MODODEPREPARO = @mododepreparo, " +
                          $"TAGS = @tags " +
                          $"WHERE ID = @id";

                var parametros = new DynamicParameters();
                parametros.Add("titulo", receita.Titulo);
                parametros.Add("descricao", receita.Descricao);
                parametros.Add("ingredientes", receita.Ingredientes);
                parametros.Add("mododepreparo", receita.ModoDePreparo);
                parametros.Add("tags", receita.Tags);
                parametros.Add("id", receita.ID);

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
                var sql = $"DELETE FROM RECEITAS WHERE ID = @id";

                var parametros = new DynamicParameters();
                parametros.Add("id", id);

                if (Connection.Execute(sql, parametros) > 0)
                    result = true;
            }
            return result;
        }
    }
}