using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeW.WEB.Models.Enums;

namespace WeW.WEB.Models
{
    public class RegistroDeVenda
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public double Montante { get; set; }

        public StatusProdutos Status { get; set; }
    }
}