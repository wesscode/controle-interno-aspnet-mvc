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
            var strQuery = "INSERT INTO Produto (cod, nome, descricao, preco, quantidade, categoria)";
                strQuery += $" VALUES ('{produto.Cod}', '{produto.Nome}', '{produto.Descricao}', '{produto.Preco}', '{produto.Estoque}', '{produto.Categoria}')";

            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

        public void Alterar(Produto produto)
        {
            var strQuery = "UPDATE Produto SET";
            strQuery += $" nome = '{produto.Nome}', descricao = '{produto.Descricao}', preco = '{produto.Preco}', estoque = '{produto.Estoque}', WHERE cod = '{produto.Cod}'";

            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

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
                var strQuery = "SELECT cod, Pro.nome, descricao, preco, Categoria.nome, Estoque.quantidade FROM Produto Pro"
                              +" INNER JOIN Categoria ON Categoria.id = Pro.categoria INNER JOIN Estoque ON Estoque.id = Pro.estoque ORDER BY Pro.nome";
                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno);
            }
        }

        public Produto ListarPorId(int id)
        {
            using (Base = new Base())
            {
                var strQuery = $"SELECT cod, nome, descricao, preco, estoque, categoria FROM Produto WHERE cod = '{id}'";
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
                    Estoque = new EstoqueProduto()
                    {
                        Quantidade = int.Parse(reader["quantidade"].ToString())
                    },
                    Categoria = new Categoria()
                    {
                        Nome = reader["nome"].ToString()
                    }
                    
                };

                produtos.Add(TempoObjeto);
            }
            reader.Close();
            return produtos;
        }
    }
}