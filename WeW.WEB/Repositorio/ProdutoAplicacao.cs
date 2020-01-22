using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WeW.WEB.Models;

namespace WeW.WEB.Repositorio
{
    public class ProdutoAplicacao
    {
        private Base Base;

        public void Inserir(Produto produto)
        {
            var strQuery = "INSERT INTO Produto (cod, nome, descricao, preco, categoria, quantidade )";
                strQuery += $" VALUES ('{produto.Cod}', '{produto.Nome}', '{produto.Descricao}', '{produto.Preco}', '{produto.CategoriaId}', '{produto.Quantidade}')";

            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

        public void Alterar(Produto produto)
        {
            var strQuery = "UPDATE Produto SET";
            strQuery += $" nome = '{produto.Nome}', descricao = '{produto.Descricao}', preco = '{produto.Preco}', categoria = '{produto.CategoriaId}', quantidade = '{produto.Quantidade}' WHERE cod = '{produto.Cod}'";

            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

        //public void Salvar(Produto produto)
        //{
        //    if (produto.Cod > 0)
        //    {
        //        Alterar(produto);
        //    }
        //    else {
        //        Inserir(produto);
        //    }
        //}

        public void Excluir(int id)
        {
            var strQuery = $"DELETE FROM Produto WHERE cod '{id}'";

            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

        public List<Produto> ListarTodos()
        {
            using (Base = new Base())
            {
                var strQuery = "SELECT cod, Pro.nome, descricao, preco, Categoria.id as c, Categoria.nome as cate, quantidade FROM Produto Pro"
                              +" INNER JOIN Categoria ON Categoria.id = Pro.categoria ORDER BY Pro.nome";
                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno);
            }
        }

        public Produto ListarPorId(int id)
        {
            using (Base = new Base())
            {
                var strQuery = $"SELECT cod, nome, descricao, preco, categoria c, categoria cate, quantidade FROM Produto WHERE cod = '{id}'";
                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno).FirstOrDefault();
            }
        }

        private List<Produto> ReaderEmList(SqlDataReader reader)
        {
            var produtos = new List<Produto>();

            while (reader.Read())
            {
                var TempoObjeto = new Produto()
                {
                    Cod = int.Parse(reader["cod"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Descricao = reader["descricao"].ToString(),
                    Preco = double.Parse(reader["preco"].ToString()),                  
                    Quantidade = int.Parse(reader["quantidade"].ToString()),
                    CategoriaId = int.Parse(reader["c"].ToString()),
                    Categoria = new Categoria()
                    {
                        Nome = reader["cate"].ToString()
                    }                    
                };

                produtos.Add(TempoObjeto);
            }
            reader.Close();
            return produtos;
        }
    }
}