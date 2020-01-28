using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeW.WEB.Models;
using WeW.WEB.Repositorio;
using X.PagedList;

namespace WeW.WEB.Controllers
{
    public class ProdutoController : Controller
    {
        ProdutoAplicacao appProduto = new ProdutoAplicacao();
        CategoriaAplicacao appCategoria = new CategoriaAplicacao();
        // GET: Produto
        public ActionResult Index(int pagina = 1)
        {            
            var listarProdutos = appProduto.ListarTodos().ToPagedList(pagina, 5);

            return View(listarProdutos);
        }

        public ActionResult Pesquisar(string Pesquisa, int pagina = 1)
        {
            var listarProdutos = appProduto.ListarTodos().ToPagedList(pagina, 5);

            if (!string.IsNullOrEmpty(Pesquisa))
            {
                var filtro = appProduto.ListarFiltro(Pesquisa).ToPagedList(pagina, 5);
                return PartialView("_Produto", filtro);
            }

            return PartialView("_Produto", listarProdutos);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.ListarCategoria = new SelectList(appCategoria.ListarTodos(), "id", "nome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Produto produto)
        {
            ViewBag.ListarCategoria = new SelectList(appCategoria.ListarTodos(), "id", "nome");
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
            ViewBag.ListarCategoria = new SelectList(appCategoria.ListarTodos(), "id", "nome");
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
         ViewBag.ListarCategoria = new SelectList(appCategoria.ListarTodos(), "id", "nome");

            if (ModelState.IsValid)
            {
                appProduto.Alterar(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public ActionResult Detalhes(int id)
        {           
            var produto = appProduto.ListarPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
    }
}