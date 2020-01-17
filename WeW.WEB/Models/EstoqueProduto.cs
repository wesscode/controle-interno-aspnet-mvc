using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeW.WEB.Models
{
    public class EstoqueProduto
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public List<Produto> Produtos { get; set; } = new List<Produto>();
       
    }
}