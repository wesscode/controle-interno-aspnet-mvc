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
            decimal preco = decimal.Parse(produto.Preco);
            var strQuery = "INSERT INTO Produto (cod, nome, descricao, preco, categoria, quantidade )";
                strQuery += $" VALUES ('{produto.Cod}', '{produto.Nome}', '{produto.Descricao}', {preco.ToString().Replace(",",".")}, '{produto.CategoriaId}', '{produto.Quantidade}')";               
            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

        public void Alterar(Produto produto)
        {
            decimal preco = decimal.Parse(produto.Preco);
            var strQuery = "UPDATE Produto SET";
            strQuery += $" nome = '{produto.Nome}', descricao = '{produto.Descricao}', preco = {preco.ToString().Replace(",", ".")}, categoria = '{produto.CategoriaId}', quantidade = '{produto.Quantidade}' WHERE cod = '{produto.Cod}'";            

            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }
        
        public void Deletar(int id)
        {
            var strQuery = $"DELETE FROM Produto WHERE cod '{id}'";

            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

        public List<Produto> ListarFiltro(string pFiltro)
        {
            using (Base = new Base())
            {
                var strQuery = "SELECT cod, Pro.nome, descricao, preco, Categoria.id as c, Categoria.nome as cate, quantidade FROM Produto Pro";
                strQuery += " INNER JOIN Categoria ON Categoria.id = Pro.categoria";
                strQuery += $" WHERE cod LIKE '%{pFiltro}%' OR Pro.nome LIKE '%{pFiltro}%' ORDER BY Pro.nome";

                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno);
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

        public Produto ListarPorId(long id)
        {
            using (Base = new Base())
            {
                var strQuery = "SELECT cod, Pro.nome, descricao, preco, Categoria.id c, Categoria.nome cate, quantidade FROM Produto Pro"
                               +$" INNER JOIN Categoria ON Categoria.id = Pro.categoria WHERE cod = '{id}'";
                
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
                    Cod = long.Parse(reader["cod"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Descricao = reader["descricao"].ToString(),
                    Preco = reader["preco"].ToString(),                  
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