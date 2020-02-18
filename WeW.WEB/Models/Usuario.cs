using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeW.WEB.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome é um campo Obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é um campo Obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Login é um campo Obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é um campo Obrigatório.")]
        public string Senha { get; set; }
    }
}