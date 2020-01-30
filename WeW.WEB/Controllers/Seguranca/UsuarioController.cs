using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeW.WEB.Models;
using WeW.WEB.Repositorio;

namespace WeW.WEB.Controllers.Seguranca
{
    public class UsuarioController : Controller
    {
        UsuarioAplicacao appUsuario = new UsuarioAplicacao();

        // GET: Usuario
        public ActionResult Index()
        {
            var listarUsuarios = appUsuario.ListarTodos();
            return View(listarUsuarios);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                appUsuario.Inserir(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        public ActionResult Alterar(int id)
        {
            var usuario = appUsuario.ListarPorId(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                appUsuario.Alterar(usuario);
                return RedirectToAction(nameof(Index));
            }
            
            return View(usuario);
        }
    }
}