using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeW.WEB.Models
{
    public class Produto
    {
        [Required]
        public int Cod { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }
     
        public double Preco { get; set; }

        public int EstoqueId { get; set; }

        public EstoqueProduto Estoque { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}