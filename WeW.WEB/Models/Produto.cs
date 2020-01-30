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
        [Display(Name = "Código")]
        public int Cod { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [Range( 0.50, 10000.00, ErrorMessage = "valor do produto deve ser entre 1,00 a 10.000,00")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Display(Name = "Categoria")]
        [Required]
        public int CategoriaId { get; set; }
        
        public Categoria Categoria { get; set; }
    }
}