using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
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

        // GET: VehiculoTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehiculoType vehiculoType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(vehiculoType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya Existe este tipo de Vehiculos.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(vehiculoType);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehiculoType vehiculoType = await _context.VehiculoTypes.FindAsync(id);
            if (vehiculoType == null)
            {
                return NotFound();
            }

            return View(vehiculoType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehiculoType vehiculoType)
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
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya Existe este tipo de Vehiculos.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }
            return View(vehiculoType);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehiculoType vehiculoType = await _context.VehiculoTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculoType == null)
            {
                return NotFound();
            }
            _context.VehiculoTypes.Remove(vehiculoType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
