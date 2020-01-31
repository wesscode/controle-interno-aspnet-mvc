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
        public string Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Display(Name = "Categoria")]
        [Required]
        public int CategoriaId { get; set; }
        
        public Categoria Categoria { get; set; }
    }
}