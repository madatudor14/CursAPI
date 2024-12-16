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
    public class UtilizatoriController : Controller
    {
        private readonly BibliotecaContext _context;

        public UtilizatoriController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Utilizatori
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizatori.ToListAsync());
        }

        // GET: Utilizatori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizatori = await _context.Utilizatori
                .FirstOrDefaultAsync(m => m.IdUtilizator == id);
            if (utilizatori == null)
            {
                return NotFound();
            }

            return View(utilizatori);
        }

        // GET: Utilizatori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizatori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUtilizator,NumeUtilizator,PrenumeUtilizator,Email,Telefon,DataInregistrare")] Utilizatori utilizatori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilizatori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizatori);
        }

        // GET: Utilizatori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizatori = await _context.Utilizatori.FindAsync(id);
            if (utilizatori == null)
            {
                return NotFound();
            }
            return View(utilizatori);
        }

        // POST: Utilizatori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtilizator,NumeUtilizator,PrenumeUtilizator,Email,Telefon,DataInregistrare")] Utilizatori utilizatori)
        {
            if (id != utilizatori.IdUtilizator)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizatori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizatoriExists(utilizatori.IdUtilizator))
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
            return View(utilizatori);
        }

        // GET: Utilizatori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizatori = await _context.Utilizatori
                .FirstOrDefaultAsync(m => m.IdUtilizator == id);
            if (utilizatori == null)
            {
                return NotFound();
            }

            return View(utilizatori);
        }

        // POST: Utilizatori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizatori = await _context.Utilizatori.FindAsync(id);
            if (utilizatori != null)
            {
                _context.Utilizatori.Remove(utilizatori);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizatoriExists(int id)
        {
            return _context.Utilizatori.Any(e => e.IdUtilizator == id);
        }
    }
}
