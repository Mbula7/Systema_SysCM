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
    public class CondutorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CondutorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Condutors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Condutors.Include(c => c.Municipio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Condutors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condutor = await _context.Condutors
                .Include(c => c.Municipio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condutor == null)
            {
                return NotFound();
            }

            return View(condutor);
        }

        // GET: Condutors/Create
        public IActionResult Create()
        {
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id");
            return View();
        }

        // POST: Condutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCompleto,NumeroBI,DataNascimento,Sexo,Telefone,Email,Endereco,NumeroCartaConducao,CategoriaCarta,DataEmissaoCarta,DataValidadeCarta,Foto,Estado,DataRegisto,MunicipioId")] Condutor condutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", condutor.MunicipioId);
            return View(condutor);
        }

        // GET: Condutors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condutor = await _context.Condutors.FindAsync(id);
            if (condutor == null)
            {
                return NotFound();
            }
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", condutor.MunicipioId);
            return View(condutor);
        }

        // POST: Condutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCompleto,NumeroBI,DataNascimento,Sexo,Telefone,Email,Endereco,NumeroCartaConducao,CategoriaCarta,DataEmissaoCarta,DataValidadeCarta,Foto,Estado,DataRegisto,MunicipioId")] Condutor condutor)
        {
            if (id != condutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondutorExists(condutor.Id))
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
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "Id", "Id", condutor.MunicipioId);
            return View(condutor);
        }

        // GET: Condutors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condutor = await _context.Condutors
                .Include(c => c.Municipio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condutor == null)
            {
                return NotFound();
            }

            return View(condutor);
        }

        // POST: Condutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var condutor = await _context.Condutors.FindAsync(id);
            if (condutor != null)
            {
                _context.Condutors.Remove(condutor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondutorExists(int id)
        {
            return _context.Condutors.Any(e => e.Id == id);
        }
    }
}
