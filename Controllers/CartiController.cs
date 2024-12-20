using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryProject.Models;


namespace LibraryProject.Controllers
{
    public class CartiController : Controller
    {
        private readonly BibliotecaContext _context;

        public CartiController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Carti
        public async Task<IActionResult> Index(string searchFilter)
        {
            var books = _context.Carti.AsQueryable();

            if(!string.IsNullOrEmpty(searchFilter))
            {
                string lowerSearchString = searchFilter.ToLower();
                 books = books.Where(d => d.Titlu.ToLower().Contains(lowerSearchString));
            }

            ViewBag.SearchString = searchFilter;

            return View(books);
        }

        // GET: Carti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            


            if (id == null)
            {
                return NotFound();
            }

            var carti = await _context.Carti
                .Include(c => c.IdAutorNavigation)
                .Include(c => c.IdCategorieNavigation)
                .FirstOrDefaultAsync(m => m.IdCarte == id);
            if (carti == null)
            {
                return NotFound();
            }

            return View(carti);
        }

        // GET: Carti/Create
        public IActionResult Create()
        {
            ViewData["IdAutor"] = new SelectList(_context.Autori.Select(a => new { IdAutor = a.IdAutor, FullName = a.PrenumeAutor   + " " + a.NumeAutor }), "IdAutor", "FullName");
            ViewData["IdCategorie"] = new SelectList(_context.Categorii, "IdCategorie", "NumeCategorie");
            return View();
        }

        // POST: Carti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create([Bind("IdCarte,Titlu,IdCategorie,IdAutor,AnPublicare,NumarPagini,StocDisponibil")] Carti carti)
        {
            ViewData["IdAutor"] = new SelectList(_context.Autori, "IdAutor", "IdAutor", carti.IdAutor);
            ViewData["IdCategorie"] = new SelectList(_context.Categorii, "IdCategorie", "IdCategorie", carti.IdCategorie);
            
            
                _context.Add(carti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            
        }

        // GET: Carti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carti = await _context.Carti.FindAsync(id);
            if (carti == null)
            {
                return NotFound();
            }
            ViewData["IdAutor"] = new SelectList(_context.Autori.Select(a => new { IdAutor = a.IdAutor, FullName = a.PrenumeAutor + " " + a.NumeAutor }), "IdAutor", "FullName");
            ViewData["IdCategorie"] = new SelectList(_context.Categorii, "IdCategorie", "NumeCategorie", carti.IdCategorie);
            return View(carti);
        }

        // POST: Carti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCarte,Titlu,IdCategorie,IdAutor,AnPublicare,NumarPagini,StocDisponibil")] Carti carti)
        {
            if (id != carti.IdCarte)
            {
                return NotFound();
            }

            ViewData["IdAutor"] = new SelectList(_context.Autori, "IdAutor", "IdAutor", carti.IdAutor);
            ViewData["IdCategorie"] = new SelectList(_context.Categorii, "IdCategorie", "IdCategorie", carti.IdCategorie);


            _context.Update(carti);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));




        }

        // GET: Carti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carti = await _context.Carti
                .Include(c => c.IdAutorNavigation)
                .Include(c => c.IdCategorieNavigation)
                .FirstOrDefaultAsync(m => m.IdCarte == id);
            if (carti == null)
            {
                return NotFound();
            }

            return View(carti);
        }

        // POST: Carti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var carti = await _context.Carti.FindAsync(id);
            if (carti != null)
            {
                _context.Carti.Remove(carti);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartiExists(int id)
        {
            return _context.Carti.Any(e => e.IdCarte == id);
        }

       


    }
}
