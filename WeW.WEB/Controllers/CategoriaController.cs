using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeW.WEB.Models;
using WeW.WEB.Repositorio;

namespace WeW.WEB.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        CategoriaAplicacao appCategoria = new CategoriaAplicacao();

        // GET: Categoria       
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
                if (appCategoria.ListarPorNome(categoria.Nome) != null)
                {
                    TempData["error"] = "Nome da categoria já cadastrada.";
                    return View(categoria);
                }
                appCategoria.Salvar(categoria);
                TempData["success"] = "Categoria cadastrada. ";
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
                if (appCategoria.ListarPorNome(categoria.Nome) != null)
                {
                    TempData["error"] = "Nome da categoria já cadastrada.";
                    return View(categoria);
                }
                else
                {
                    appCategoria.Salvar(categoria);
                    TempData["success"] = "Nome da categoria alterada";
                    return RedirectToAction(nameof(Index));
                }
                
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