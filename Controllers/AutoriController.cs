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
    public class AutoriController : Controller
    {
        private readonly BibliotecaContext _context;

        public AutoriController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Autori
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autori.ToListAsync());
        }

        // GET: Autori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autori = await _context.Autori
                .FirstOrDefaultAsync(m => m.IdAutor == id);
            if (autori == null)
            {
                return NotFound();
            }

            return View(autori);
        }

        // GET: Autori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAutor,NumeAutor,PrenumeAutor")] Autori autori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autori);
        }

        // GET: Autori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autori = await _context.Autori.FindAsync(id);
            if (autori == null)
            {
                return NotFound();
            }
            return View(autori);
        }

        // POST: Autori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAutor,NumeAutor,PrenumeAutor")] Autori autori)
        {
            if (id != autori.IdAutor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoriExists(autori.IdAutor))
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
            return View(autori);
        }

        // GET: Autori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autori = await _context.Autori
                .FirstOrDefaultAsync(m => m.IdAutor == id);
            if (autori == null)
            {
                return NotFound();
            }

            return View(autori);
        }

        // POST: Autori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autori = await _context.Autori.FindAsync(id);
            if (autori != null)
            {
                _context.Autori.Remove(autori);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoriExists(int id)
        {
            return _context.Autori.Any(e => e.IdAutor == id);
        }
    }
}
