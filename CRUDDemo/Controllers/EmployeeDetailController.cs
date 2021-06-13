using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDDemo.Models;
using CRUDDemoAPI.Models;

namespace CRUDDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailController : ControllerBase
    {
        private readonly EmployeeDetailContext _context;
                    
        public EmployeeDetailController(EmployeeDetailContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeeDetails()
        {
            return await _context.EmployeeDetails.ToListAsync();
        }

        // GET: api/EmployeeDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetail>> GetEmployeeDetail(int id)
        {
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);

            if (employeeDetail == null)
            {
                return NotFound();
            }

            return employeeDetail;
        }

        // PUT: api/EmployeeDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDetail(int id, EmployeeDetail employeeDetail)
        {
            if (id != employeeDetail.EmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(employeeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(id))
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

        // POST: api/EmployeeDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeDetail>> PostEmployeeDetail(EmployeeDetail employeeDetail)
        {
            _context.EmployeeDetails.Add(employeeDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeDetail", new { id = employeeDetail.EmployeeID }, employeeDetail);
        }

        // DELETE: api/EmployeeDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDetail>> DeleteEmployeeDetail(int id)
        {
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            _context.EmployeeDetails.Remove(employeeDetail);
            await _context.SaveChangesAsync();

            return employeeDetail;
        }

        private bool EmployeeDetailExists(int id)
        {
            return _context.EmployeeDetails.Any(e => e.EmployeeID == id);
        }
    }
}
