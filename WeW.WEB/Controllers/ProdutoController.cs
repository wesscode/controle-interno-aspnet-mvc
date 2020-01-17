using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeW.WEB.Models;
using WeW.WEB.Repositorio;

namespace WeW.WEB.Controllers
{
    public class ProdutoController : Controller
    {
        ProdutoAplicacao appProduto = new ProdutoAplicacao();
        // GET: Produto
        public ActionResult Index()
        {            
            var listarProdutos = appProduto.ListarTodos();

            return View(listarProdutos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                appProduto.Inserir(produto);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        public ActionResult Alterar(int id)
        {
            var produto = appProduto.ListarPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                appProduto.Alterar(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }
    }
}