using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeW.WEB.Models;
using WeW.WEB.Models.ViewModels;
using WeW.WEB.Repositorio;

namespace WeW.WEB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        UsuarioAplicacao appUsuario = new UsuarioAplicacao();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entrar(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                Usuario usuarioAutenticado = appUsuario.RecuperarUsuarioLoginSenha(new Usuario { Login = loginVM.Login, Senha = loginVM.Senha });
                if (usuarioAutenticado != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }

            return View("Index", loginVM);
        }
    }
}