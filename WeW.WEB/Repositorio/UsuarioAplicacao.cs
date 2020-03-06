using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WeW.WEB.Helpers;
using WeW.WEB.Models;

namespace WeW.WEB.Repositorio
{
    public class UsuarioAplicacao
    {
        private Base Base;

        private void Inserir(Usuario usuario)
        {
            var strQuery = $"INSERT INTO Usuario (nome, email, login, senha) VALUES ('{usuario.Nome}', '{usuario.Email}', '{usuario.Login}', '{usuario.Senha}')";
            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
            
        }
        private void Alterar(Usuario usuario)
        {
            var strQuery = $"UPDATE Usuario SET nome = '{usuario.Nome}', email = '{usuario.Email}', login = '{usuario.Login}'";
                strQuery += $" WHERE id = '{usuario.Id}'";
            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }
        public void Salvar(Usuario usuario)
        {
            if (usuario.Id > 0)
            {               
                Alterar(usuario);
            }
            else
            {
                Inserir(usuario);
            }
        }
        public void Deletar(int id)
        {
            var strQuery = $"DELETE FROM Usuario WHERE Id = '{id}'";
            using (Base = new Base())
            {
                Base.ExecutaComando(strQuery);
            }
        }

        public List<Usuario> ListarTodos()
        {
            using (Base = new Base())
            {
                var strQuery = "SELECT id, nome, email, login, senha FROM Usuario";
                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno);
            }
        }

        public Usuario ListarPorId(int id)
        {
            using (Base = new Base())
            {
                var strQuery = $"SELECT id, nome, email, login, senha FROM Usuario WHERE id = '{id}'";
                var retorno = Base.ExecutaComandoComRetorno(strQuery);
                return ReaderEmList(retorno).FirstOrDefault();
            }
        }

        public Usuario ValidaUsuarioLoginSenha(Usuario usuario)
        {
            using (Base = new Base())
            {
                var strQuery = $"SELECT * FROM Usuario where login = '{usuario.Login}' and senha = '{CriptoHelper.HashMD5(usuario.Senha)}'";
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
                    Senha = reader["senha"].ToString(),
                };
                usuarios.Add(TempoObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}