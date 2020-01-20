using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeW.WEB.Models
{
    public class RegistroDeVenda
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public double Montante { get; set; }       
    }
}