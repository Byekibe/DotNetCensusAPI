using MarpleApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarpleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CensusController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CensusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /api/Census
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Census>>> GetCensus()
        {
            return await _context.Census.ToListAsync();
        }

        // GET: /api/Census/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Census>> GetCensus(int id)
        {
            var census = await _context.Census.FindAsync(id);

            if (census == null)
            {
                return NotFound();
            }

            return census;
        }

        // POST: /api/Census
        [HttpPost]
        public async Task<ActionResult<Census>> PostCensus(Census census)
        {
            _context.Census.Add(census);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCensus), new { id = census.Id }, census);
        }

        // PUT: /api/Census/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCensus(int id, Census census)
        {
            if (id != census.Id)
            {
                return BadRequest();
            }

            _context.Entry(census).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: /api/Census/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCensus(int id)
        {
            var census = await _context.Census.FindAsync(id);
            if (census == null)
            {
                return NotFound();
            }

            _context.Census.Remove(census);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
