using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
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

        [HttpPost]       
        public ActionResult Entrar(LoginVM loginVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuarioAutenticado = appUsuario.ValidaUsuarioLoginSenha(new Usuario { Login = loginVM.Login, Senha = loginVM.Senha});
             
                    if (usuarioAutenticado != null)
                    {
                        FormsAuthentication.SetAuthCookie(usuarioAutenticado.Nome, false); //informando qual dado do usuario foi armazenado em cookie                      
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["warning"] = "Login ou Senha inválidas";

                return View("Index", loginVM);
            }
            catch (Exception ex)
            {

               throw ex;
            }                                         
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();            
            return View("Index");
        }
        
    }
}