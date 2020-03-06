using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WeW.WEB.Helpers
{
    public class CriptoHelper
    {
        public static string HashMD5(string val)
        {
            var bytes = Encoding.ASCII.GetBytes(val); //forma de caracter ascii formado em bytes
            var md5 = MD5.Create(); //criando o objeto md5
            var hash = md5.ComputeHash(bytes); //fazendo o hash(criptografia), retorna vetor de bytes
            var retorno = string.Empty;

            for (int i = 0; i < hash.Length; i++)
            {
                retorno += hash[i].ToString("x2");
            }

            return retorno;
        }
    }
}