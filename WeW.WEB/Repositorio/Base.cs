using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WeW.WEB.Repositorio
{
    public class Base : IDisposable
    {
        private readonly SqlConnection conexao;

        public Base()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var cmdSelect = new SqlCommand(strQuery, conexao);
            cmdSelect.ExecuteNonQuery();
        }
        
        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdSelect = new SqlCommand(strQuery, conexao);
            return cmdSelect.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }            
        }
    }
}