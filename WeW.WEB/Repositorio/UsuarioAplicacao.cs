using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WeW.WEB.Models;

namespace WeW.WEB.Repositorio
{
    public class UsuarioAplicacao
    {
        private Base Base;

        public void Inserir(Usuario usuario)
        {
            var strQuery = $"INSERT INTO Usuario (nome, email, login, senha) VALUES ('{usuario.Nome}', '{usuario.Email}', '{usuario.Login}', '{usuario.Senha}')";
            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
            
        }
        public void Alterar(Usuario usuario)
        {
            var strQuery = $"UPDATE Usuario SET nome = '{usuario.Nome}', email = '{usuario.Email}', login = '{usuario.Login}', senha = '{usuario.Senha}'";
                strQuery += $" WHERE id = '{usuario.Id}'";
            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

        //public void Salvar(Produto produto)
        //{
        //    if (produto.Cod > 0)
        //    {
        //        Inserir(produto);
        //    }
        //    else
        //    {
        //        Alterar(produto);
        //    }
        //}

        public void Deletar()
        {

        }

        public List<Usuario> ListarTodos()
        {
            using (Base = new Base())
            {
                var strQuery = "SELECT * FROM Usuario";
                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno);
            }
        }

        public Usuario ListarPorId(int id)
        {
            using (Base = new Base())
            {
                var strQuery = $"SELECT * FROM Usuario WHERE id = '{id}'";
                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno).FirstOrDefault();
            }
        }

        private List<Usuario> ReaderEmList(SqlDataReader reader)
        {
            var usuarios = new List<Usuario>();

            while (reader.Read())
            {
                var TempoObjeto = new Usuario()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Email = reader["email"].ToString(),
                    Login = reader["login"].ToString(),
                    Senha = reader["senha"].ToString()
                };
                usuarios.Add(TempoObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}