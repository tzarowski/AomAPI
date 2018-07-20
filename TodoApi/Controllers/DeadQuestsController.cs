using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeadQuestsController : ControllerBase
    {
        private readonly DeadQuestContext _context;

        public DeadQuestsController(DeadQuestContext context)
        {
            _context = context;
        }

        // GET: api/DeadQuests
        [HttpGet]
        public IEnumerable<DeadQuest> GetDeadQuests()
        {
            return _context.DeadQuests;
        }

        // GET: api/DeadQuests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeadQuest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deadQuest = await _context.DeadQuests.FindAsync(id);

            if (deadQuest == null)
            {
                return NotFound();
            }

            return Ok(deadQuest);
        }

        // PUT: api/DeadQuests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeadQuest([FromRoute] int id, [FromBody] DeadQuest deadQuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deadQuest.Id)
            {
                return BadRequest();
            }

            _context.Entry(deadQuest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeadQuestExists(id))
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

        // POST: api/DeadQuests
        [HttpPost]
        public async Task<IActionResult> PostDeadQuest([FromBody] DeadQuest deadQuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeadQuests.Add(deadQuest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeadQuest", new { id = deadQuest.Id }, deadQuest);
        }

        // DELETE: api/DeadQuests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeadQuest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deadQuest = await _context.DeadQuests.FindAsync(id);
            if (deadQuest == null)
            {
                return NotFound();
            }

            _context.DeadQuests.Remove(deadQuest);
            await _context.SaveChangesAsync();

            return Ok(deadQuest);
        }

        private bool DeadQuestExists(int id)
        {
            return _context.DeadQuests.Any(e => e.Id == id);
        }
    }
}