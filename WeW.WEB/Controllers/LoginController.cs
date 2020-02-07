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
            if (ModelState.IsValid)
            {
                Usuario usuarioAutenticado = appUsuario.RecuperarUsuarioLoginSenha(new Usuario { Login = loginVM.Login, Senha = loginVM.Senha });
                if (usuarioAutenticado != null)
                {
                    FormsAuthentication.SetAuthCookie(loginVM.Login, false);
                    TempData["LoginName"] = loginVM.Login;
                    return RedirectToAction("Index", "Home");
                }               
            }            
            TempData["warning"] = "Mensagem de warning!!";
            TempData["success"] = "Mensagem de sucesso!!";
            TempData["info"] = "Mensagem de informação!!";
            TempData["error"] = "Mensagem de erro!!";
            return View("Index", loginVM);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            TempData["LoginName"] = null;
            return View("Index");
        }

        //public class SessionContext
        //{
        //    private UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();

        //    public void SetAuthenticationToken(string name, bool isPersistant, Usuario userData)
        //    {
        //        string data = null;
        //        if (userData != null)
        //        {
        //            data = new JavaScriptSerializer().Serialize(userData);
        //        }

        //        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,name, DateTime.Now, DateTime.Now.AddDays(1), isPersistant, userData.ToString());

        //        string cookieData = FormsAuthentication.Encrypt(ticket);
        //        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData)
        //        {
        //            HttpOnly = true,
        //            Expires = ticket.Expiration
        //        };

        //        HttpContext.Current.Response.Cookies.Add(cookie);
        //    }

        //    public Usuario GetUserData()
        //    {
        //        Usuario userData = null;
               
        //            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        //            if (cookie != null)
        //            {
        //                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
        //                userData = JsonConvert.DeserializeObject<Usuario>(ticket.UserData);
        //            }
              
        //        return userData;
        //    }
        //}
    }
}