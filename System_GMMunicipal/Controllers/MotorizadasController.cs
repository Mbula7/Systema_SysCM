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
    public class MotorizadasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotorizadasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Motorizadas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Motorizadas.Include(m => m.Condutor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Motorizadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorizada = await _context.Motorizadas
                .Include(m => m.Condutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorizada == null)
            {
                return NotFound();
            }

            return View(motorizada);
        }

        // GET: Motorizadas/Create
        public IActionResult Create()
        {
            ViewData["condutorId"] = new SelectList(_context.Condutors, "Id", "Id");
            return View();
        }

        // POST: Motorizadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Matricula,Marca,Modelo,AnoFabrico,Cor,NumeroChassi,NumeroMotor,Cilindrada,CapacidadeCarga,Estado,DataRegisto,condutorId")] Motorizada motorizada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motorizada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["condutorId"] = new SelectList(_context.Condutors, "Id", "Id", motorizada.condutorId);
            return View(motorizada);
        }

        // GET: Motorizadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorizada = await _context.Motorizadas.FindAsync(id);
            if (motorizada == null)
            {
                return NotFound();
            }
            ViewData["condutorId"] = new SelectList(_context.Condutors, "Id", "Id", motorizada.condutorId);
            return View(motorizada);
        }

        // POST: Motorizadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Matricula,Marca,Modelo,AnoFabrico,Cor,NumeroChassi,NumeroMotor,Cilindrada,CapacidadeCarga,Estado,DataRegisto,condutorId")] Motorizada motorizada)
        {
            if (id != motorizada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorizada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorizadaExists(motorizada.Id))
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
            ViewData["condutorId"] = new SelectList(_context.Condutors, "Id", "Id", motorizada.condutorId);
            return View(motorizada);
        }

        // GET: Motorizadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorizada = await _context.Motorizadas
                .Include(m => m.Condutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorizada == null)
            {
                return NotFound();
            }

            return View(motorizada);
        }

        // POST: Motorizadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motorizada = await _context.Motorizadas.FindAsync(id);
            if (motorizada != null)
            {
                _context.Motorizadas.Remove(motorizada);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotorizadaExists(int id)
        {
            return _context.Motorizadas.Any(e => e.Id == id);
        }
    }
}
