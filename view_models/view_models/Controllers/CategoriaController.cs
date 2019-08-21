using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using view_models.Models;
using view_models.ViewModels;

namespace view_models.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly viewmodeldbcontexto _context;

        public CategoriaController(viewmodeldbcontexto context)
        {
            _context = context;
        }

        // GET: Categoria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.ToListAsync());
        }

        //GET CUSTOMIZADO - RECEBE PARAM CATEGORIA E RETORNA SEUS PRODUTOS
        [Route("/{id?}/produtos")]
        public IActionResult CategProdutos(int id)
        {
            
            var objLista = _context.Produtos.Include(x => x.Categoria).Where(x => x.CategoriaId == id);
            
            List<decimal> lista = new List<decimal>();

            decimal soma2=0;

            foreach (var tot in objLista)
            {
               lista.Add(tot.Preco);
               soma2 = soma2 + tot.Preco;
            }
            
            ViewData["listapreco"] = lista.Sum();
            ViewData["soma22"] = soma2;

            return View(objLista);
        }

        //GET IMPLEMENTANDO UMA VIEW MODEL
        public IActionResult Index3()
        {
            var objJoin = _context.Categorias.Include(x => x.Produtos).ToList();

            List<CategoriaViewModel> categoriaVM = new List<CategoriaViewModel>();
            
            foreach(var item in objJoin){

                CategoriaViewModel vm = new CategoriaViewModel();
                
                vm.CategoriaId = item.CategoriaId.ToString();
                vm.Nome = item.Nome;
                vm.QuantidadeProdutos = item.Produtos.Count().ToString();
                vm.SomaProdutos = item.Produtos.Sum(x => x.Preco);

                categoriaVM.Add(vm);
            }
            
            return View(categoriaVM.ToList());     
        }

        // GET: Categoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,Nome")] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.CategoriaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.CategoriaId == id);
        }
    }
}
