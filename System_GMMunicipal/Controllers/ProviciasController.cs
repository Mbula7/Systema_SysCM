using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System_GMMunicipal.Data;
using System_GMMunicipal.Models;

namespace System_GMMunicipal.Controllers
{
    public class ProviciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProviciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Provicias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Provicias.ToListAsync());
        }

        // GET: Provicias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provicia = await _context.Provicias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provicia == null)
            {
                return NotFound();
            }

            return View(provicia);
        }

        // GET: Provicias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provicias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameProvincia,Codigo,CreatedDate")] Provicia provicia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provicia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provicia);
        }

        // GET: Provicias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provicia = await _context.Provicias.FindAsync(id);
            if (provicia == null)
            {
                return NotFound();
            }
            return View(provicia);
        }

        // POST: Provicias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameProvincia,Codigo,CreatedDate")] Provicia provicia)
        {
            if (id != provicia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provicia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProviciaExists(provicia.Id))
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
            return View(provicia);
        }

        // GET: Provicias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provicia = await _context.Provicias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provicia == null)
            {
                return NotFound();
            }

            return View(provicia);
        }

        // POST: Provicias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provicia = await _context.Provicias.FindAsync(id);
            if (provicia != null)
            {
                _context.Provicias.Remove(provicia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProviciaExists(int id)
        {
            return _context.Provicias.Any(e => e.Id == id);
        }
    }
}
