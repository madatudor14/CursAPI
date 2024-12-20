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
    public class CategoriiController : Controller
    {
        private readonly BibliotecaContext _context;

        public CategoriiController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Categorii
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorii.ToListAsync());
        }

        // GET: Categorii/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorii = await _context.Categorii
                .FirstOrDefaultAsync(m => m.IdCategorie == id);
            if (categorii == null)
            {
                return NotFound();
            }

            return View(categorii);
        }

        // GET: Categorii/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategorie,NumeCategorie")] Categorii categorii)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorii);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorii);
        }

        // GET: Categorii/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorii = await _context.Categorii.FindAsync(id);
            if (categorii == null)
            {
                return NotFound();
            }
            return View(categorii);
        }

        // POST: Categorii/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategorie,NumeCategorie")] Categorii categorii)
        {
            if (id != categorii.IdCategorie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorii);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriiExists(categorii.IdCategorie))
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
            return View(categorii);
        }

        // GET: Categorii/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorii = await _context.Categorii
                .FirstOrDefaultAsync(m => m.IdCategorie == id);
            if (categorii == null)
            {
                return NotFound();
            }

            return View(categorii);
        }

        // POST: Categorii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hasUsed = _context.Carti.Any(i => i.IdCarte== id);
            if (hasUsed)
            {
                TempData["ErrorMessage"] = "Categoria nu poate fi stearsa deoarece este alocata unei carti";
                return RedirectToAction(nameof(Index));
            }

            var categorii = await _context.Categorii.FindAsync(id);
            if (categorii != null)
            {
                _context.Categorii.Remove(categorii);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriiExists(int id)
        {
            return _context.Categorii.Any(e => e.IdCategorie == id);
        }
    }
}
