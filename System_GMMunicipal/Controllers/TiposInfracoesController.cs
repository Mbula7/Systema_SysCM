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
    public class TiposInfracoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiposInfracoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiposInfracoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposInfracoes.ToListAsync());
        }

        // GET: TiposInfracoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposInfracoe = await _context.TiposInfracoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposInfracoe == null)
            {
                return NotFound();
            }

            return View(tiposInfracoe);
        }

        // GET: TiposInfracoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposInfracoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Descricao,ValorBase,Gravidade,Estado")] TiposInfracoe tiposInfracoe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposInfracoe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposInfracoe);
        }

        // GET: TiposInfracoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposInfracoe = await _context.TiposInfracoes.FindAsync(id);
            if (tiposInfracoe == null)
            {
                return NotFound();
            }
            return View(tiposInfracoe);
        }

        // POST: TiposInfracoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Descricao,ValorBase,Gravidade,Estado")] TiposInfracoe tiposInfracoe)
        {
            if (id != tiposInfracoe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposInfracoe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposInfracoeExists(tiposInfracoe.Id))
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
            return View(tiposInfracoe);
        }

        // GET: TiposInfracoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposInfracoe = await _context.TiposInfracoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposInfracoe == null)
            {
                return NotFound();
            }

            return View(tiposInfracoe);
        }

        // POST: TiposInfracoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposInfracoe = await _context.TiposInfracoes.FindAsync(id);
            if (tiposInfracoe != null)
            {
                _context.TiposInfracoes.Remove(tiposInfracoe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposInfracoeExists(int id)
        {
            return _context.TiposInfracoes.Any(e => e.Id == id);
        }
    }
}
