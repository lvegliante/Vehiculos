using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data;
using Vehiculos.API.Data.Entities;

namespace Vehiculos.API.Controllers.API
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class VehicleTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public VehicleTypesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoType>>> GetVehicleTypes()
        {
            return await _context.VehiculoTypes.OrderBy(x => x.Description).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoType>> GetVehicleType(int id)
        {
            VehiculoType vehicleType = await _context.VehiculoTypes.FindAsync(id);

            if (vehicleType == null)
            {
                return NotFound();
            }

            return vehicleType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleType(int id, VehiculoType vehicleType)
        {
            if (id != vehicleType.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicleType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe tipo de vehículo.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<VehiculoType>> PostVehicleType(VehiculoType vehicleType)
        {
            _context.VehiculoTypes.Add(vehicleType);

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetVehicleType", new { id = vehicleType.Id }, vehicleType);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe tipo de vehículo.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleType(int id)
        {
            VehiculoType vehicleType = await _context.VehiculoTypes.FindAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            _context.VehiculoTypes.Remove(vehicleType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}