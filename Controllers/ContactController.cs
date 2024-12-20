using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly BibliotecaContext _context;
        public ContactController(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ContactMessages messageModel)
        {
            if (ModelState.IsValid)
            {
                messageModel.CreatedAt = DateTime.Now; // Set the current date and time
                _context.Add(messageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Validate");
        }
    }
}

