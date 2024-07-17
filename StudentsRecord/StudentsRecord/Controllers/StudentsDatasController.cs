using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsRecord.Models;

namespace StudentsRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsDatasController : ControllerBase
    {
        private readonly StudentsContext _context;

        public StudentsDatasController(StudentsContext context)
        {
            _context = context;
        }

        // GET: api/StudentsDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsData>>> GetStudentsDatas()
        {
            return await _context.StudentsDatas.ToListAsync();
        }

        // GET: api/StudentsDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsData>> GetStudentsData(long id)
        {
            var studentsData = await _context.StudentsDatas.FindAsync(id);

            if (studentsData == null)
            {
                return NotFound();
            }

            return studentsData;
        }

        // PUT: api/StudentsDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsData(long id, StudentsData studentsData)
        {
            if (id != studentsData.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentsData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsDataExists(id))    
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

        // POST: api/StudentsDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsData>> PostStudentsData(StudentsData studentsData)
        {
            _context.StudentsDatas.Add(studentsData);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetStudentsData", new { id = studentsData.Id }, studentsData);
            return CreatedAtAction(nameof(PostStudentsData), new { id = studentsData.Id }, studentsData);
        }

        // DELETE: api/StudentsDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsData(long id)
        {
            var studentsData = await _context.StudentsDatas.FindAsync(id);
            if (studentsData == null)
            {
                return NotFound();
            }

            _context.StudentsDatas.Remove(studentsData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsDataExists(long id)
        {
            return _context.StudentsDatas.Any(e => e.Id == id);
        }
    }
}
