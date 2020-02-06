using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WeW.WEB.Models;

namespace WeW.WEB.Repositorio
{
    public class CategoriaAplicacao
    {
        private Base Base;

        public void Inserir(Categoria categoria)
        {
            var strQuery = $"INSERT INTO Categoria (nome) VALUES ('{categoria.Nome}')";
            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }
        public void Alterar(Categoria categoria)
        {
            var strQuery = $"UPDATE Categoria SET nome = '{categoria.Nome}' WHERE id = '{categoria.Id}'";
            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

        public void Deletar(int id)
        {
            string strQuery = $"DELETE FROM Categoria WHERE id = '{id}'";
            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

        public List<Categoria> ListarTodos()
        {
            using (Base = new Base())
            {
                string strQuery = "SELECT id, nome FROM Categoria";
                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno);
            }
        }

        public Categoria ListarPorId(int id)
        {
            using (Base = new Base())
            {
                string strQuery = $"SELECT id, nome FROM Categoria WHERE id = '{id}'";
                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno).FirstOrDefault();
            }
        }

        public Categoria ListarPorNome(string nome)
        {
            using (Base = new Base())
            {
                string strQuery = $"SELECT id, nome FROM Categoria WHERE nome = '{nome}'";
                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno).FirstOrDefault();
            }
        }

        private List<Categoria> ReaderEmList(SqlDataReader reader)
        {
            var categoria = new List<Categoria>();

            while (reader.Read())
            {
                var TempoObjeto = new Categoria()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nome = reader["nome"].ToString()
                };
                categoria.Add(TempoObjeto);
            }
            reader.Close();
            return categoria;
        }
    }
}