using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehiculos.API.Data;
using Vehiculos.API.Data.Entities;

namespace Vehiculos.API.Controllers
{
    public class VehiculoTypesController : Controller
    {
        private readonly DataContext _context;

        public VehiculoTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: VehiculoTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehiculoTypes.ToListAsync());
        }

        // GET: VehiculoTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoType = await _context.VehiculoTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculoType == null)
            {
                return NotFound();
            }

            return View(vehiculoType);
        }

        // GET: VehiculoTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculoTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] VehiculoType vehiculoType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculoType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculoType);
        }

        // GET: VehiculoTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoType = await _context.VehiculoTypes.FindAsync(id);
            if (vehiculoType == null)
            {
                return NotFound();
            }
            return View(vehiculoType);
        }

        // POST: VehiculoTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] VehiculoType vehiculoType)
        {
            if (id != vehiculoType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculoType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoTypeExists(vehiculoType.Id))
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
            return View(vehiculoType);
        }

        // GET: VehiculoTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoType = await _context.VehiculoTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculoType == null)
            {
                return NotFound();
            }

            return View(vehiculoType);
        }

        // POST: VehiculoTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculoType = await _context.VehiculoTypes.FindAsync(id);
            _context.VehiculoTypes.Remove(vehiculoType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoTypeExists(int id)
        {
            return _context.VehiculoTypes.Any(e => e.Id == id);
        }
    }
}
