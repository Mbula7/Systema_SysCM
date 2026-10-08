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
    public class AcidentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcidentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Acidentes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Acidentes.Include(a => a.Condutor).Include(a => a.Motorizada);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Acidentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acidente = await _context.Acidentes
                .Include(a => a.Condutor)
                .Include(a => a.Motorizada)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acidente == null)
            {
                return NotFound();
            }

            return View(acidente);
        }

        // GET: Acidentes/Create
        public IActionResult Create()
        {
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id");
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id");
            return View();
        }

        // POST: Acidentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataHora,Local,Descricao,Latitude,Longitude,CondutorId,MotorizadaId,TipoAcidente,Gravidade,NumeroFeridos,NumeroMortos,NumeroVeiculos,CausaProvavel,CondicoesClimaticas,EstadoVia,RegistadoPor,DataRegisto")] Acidente acidente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acidente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", acidente.CondutorId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", acidente.MotorizadaId);
            return View(acidente);
        }

        // GET: Acidentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acidente = await _context.Acidentes.FindAsync(id);
            if (acidente == null)
            {
                return NotFound();
            }
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", acidente.CondutorId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", acidente.MotorizadaId);
            return View(acidente);
        }

        // POST: Acidentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataHora,Local,Descricao,Latitude,Longitude,CondutorId,MotorizadaId,TipoAcidente,Gravidade,NumeroFeridos,NumeroMortos,NumeroVeiculos,CausaProvavel,CondicoesClimaticas,EstadoVia,RegistadoPor,DataRegisto")] Acidente acidente)
        {
            if (id != acidente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acidente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcidenteExists(acidente.Id))
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
            ViewData["CondutorId"] = new SelectList(_context.Condutors, "Id", "Id", acidente.CondutorId);
            ViewData["MotorizadaId"] = new SelectList(_context.Motorizadas, "Id", "Id", acidente.MotorizadaId);
            return View(acidente);
        }

        // GET: Acidentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acidente = await _context.Acidentes
                .Include(a => a.Condutor)
                .Include(a => a.Motorizada)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acidente == null)
            {
                return NotFound();
            }

            return View(acidente);
        }

        // POST: Acidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acidente = await _context.Acidentes.FindAsync(id);
            if (acidente != null)
            {
                _context.Acidentes.Remove(acidente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcidenteExists(int id)
        {
            return _context.Acidentes.Any(e => e.Id == id);
        }
    }
}
