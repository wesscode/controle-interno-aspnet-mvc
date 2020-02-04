using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeW.WEB.Models.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

    }
}