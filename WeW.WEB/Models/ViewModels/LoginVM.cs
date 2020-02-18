using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeW.WEB.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Login é um campo Obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é um campo Obrigatório")]
        public string Senha { get; set; }

    }
}