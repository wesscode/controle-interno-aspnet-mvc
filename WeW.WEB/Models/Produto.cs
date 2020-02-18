using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeW.WEB.Models
{
    public class Produto
    {
        [Required(ErrorMessage = "Código é um campo Obrigatório.")]
        [Display(Name = "Código")]
        public long Cod { get; set; }

        [Required(ErrorMessage = "Nome é um campo Obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preco é um campo Obrigatório.")]
        [Display(Name = "Preço")]        
        public string Preco { get; set; }

        [Required(ErrorMessage = "Quantidade é um campo Obrigatório.")]
        public int Quantidade { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Categoria é um campo Obrigatório.")]
        public int CategoriaId { get; set; }
        
        public Categoria Categoria { get; set; }
    }
}