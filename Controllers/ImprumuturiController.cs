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
    public class ImprumuturiController : Controller
    {
        private readonly BibliotecaContext _context;

        public ImprumuturiController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Imprumuturi
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Imprumuturi.Include(i => i.IdCarteNavigation).Include(i => i.IdUtilizatorNavigation);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Imprumuturi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imprumuturi = await _context.Imprumuturi
                .Include(i => i.IdCarteNavigation)
                .Include(i => i.IdUtilizatorNavigation)
                .FirstOrDefaultAsync(m => m.IdImprumut == id);
            if (imprumuturi == null)
            {
                return NotFound();
            }

            return View(imprumuturi);
        }

        // GET: Imprumuturi/Create
        public IActionResult Create()
        {
            ViewData["IdCarte"] = new SelectList(_context.Carti, "IdCarte", "Titlu");
            ViewData["IdUtilizator"] = new SelectList(_context.Utilizatori, "IdUtilizator", "NumeUtilizator");
            return View();
        }

        // POST: Imprumuturi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdImprumut,IdCarte,IdUtilizator,DataImprumut,DataReturnare,Status")] Imprumuturi imprumuturi)
        {

            ViewData["IdCarte"] = new SelectList(_context.Carti, "IdCarte", "Titlu", imprumuturi.IdCarte);
            ViewData["IdUtilizator"] = new SelectList(_context.Utilizatori, "IdUtilizator", "NumeUtilizator", imprumuturi.IdUtilizator);
            

            _context.Add(imprumuturi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: Imprumuturi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imprumuturi = await _context.Imprumuturi.FindAsync(id);
            if (imprumuturi == null)
            {
                return NotFound();
            }
            ViewData["IdCarte"] = new SelectList(_context.Carti, "IdCarte", "Titlu", imprumuturi.IdCarte);
            ViewData["IdUtilizator"] = new SelectList(_context.Utilizatori, "IdUtilizator", "NumeUtilizator", imprumuturi.IdUtilizator);
            return View(imprumuturi);
        }

        // POST: Imprumuturi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdImprumut,IdCarte,IdUtilizator,DataImprumut,DataReturnare,Status")] Imprumuturi imprumuturi)
        {
            if (id != imprumuturi.IdImprumut)
            {
                return NotFound();
            }

            ViewData["IdCarte"] = new SelectList(_context.Carti, "Titlu", "Titlu", imprumuturi.IdCarte);
            ViewData["IdUtilizator"] = new SelectList(_context.Utilizatori, "IdUtilizator", "IdUtilizator", imprumuturi.IdUtilizator);

            
                    _context.Update(imprumuturi);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            
            
            
        }

        // GET: Imprumuturi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imprumuturi = await _context.Imprumuturi
                .Include(i => i.IdCarteNavigation)
                .Include(i => i.IdUtilizatorNavigation)
                .FirstOrDefaultAsync(m => m.IdImprumut == id);
            if (imprumuturi == null)
            {
                return NotFound();
            }

            return View(imprumuturi);
        }

        // POST: Imprumuturi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var imprumuturi = await _context.Imprumuturi.FindAsync(id);
            if (imprumuturi != null)
            {
                _context.Imprumuturi.Remove(imprumuturi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImprumuturiExists(int id)
        {
            return _context.Imprumuturi.Any(e => e.IdImprumut == id);
        }
    }
}
