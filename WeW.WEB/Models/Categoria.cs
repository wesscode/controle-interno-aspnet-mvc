using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeW.WEB.Models
{
    public class Categoria
    {   [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome é um campo Obrigatório.")]
        public string Nome { get; set; }
    }
}