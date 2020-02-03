using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeW.WEB.Models;
using WeW.WEB.Repositorio;

namespace WeW.WEB.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaAplicacao appCategoria = new CategoriaAplicacao();

        // GET: Categoria
        [Authorize]
        public ActionResult Index()
        {
            var listarCategorias = appCategoria.ListarTodos();
            return View(listarCategorias);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                appCategoria.Inserir(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public ActionResult Alterar(int id)
        {
            var categoria = appCategoria.ListarPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                appCategoria.Alterar(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public ActionResult Deletar(int id)
        {
            var categoria = appCategoria.ListarPorId(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(Categoria categoria)
        {
            appCategoria.Deletar(categoria.Id);

            return RedirectToAction(nameof(Index));
        }

    }
}