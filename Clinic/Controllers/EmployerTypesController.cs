#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.Data;
using Clinic.Src.VO.Employer;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerTypesController : ControllerBase
    {
        private readonly ClinicContext _context;

        public EmployerTypesController(ClinicContext context)
        {
            _context = context;
        }

        // GET: api/EmployerTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployerType>>> GetEmployerType()
        {
            return await _context.EmployerType.ToListAsync();
        }

        // GET: api/EmployerTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployerType>> GetEmployerType(int? id)
        {
            var employerType = await _context.EmployerType.FindAsync(id);

            if (employerType == null)
            {
                return NotFound();
            }

            return employerType;
        }

        // PUT: api/EmployerTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployerType(int? id, EmployerType employerType)
        {
            if (id != employerType.Id)
            {
                return BadRequest();
            }

            _context.Entry(employerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployerTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployerType>> PostEmployerType(EmployerType employerType)
        {
            _context.EmployerType.Add(employerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployerType", new { id = employerType.Id }, employerType);
        }

        // DELETE: api/EmployerTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployerType(int? id)
        {
            var employerType = await _context.EmployerType.FindAsync(id);
            if (employerType == null)
            {
                return NotFound();
            }

            _context.EmployerType.Remove(employerType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployerTypeExists(int? id)
        {
            return _context.EmployerType.Any(e => e.Id == id);
        }
    }
}
