﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LexiconLMSBlazor.Server.Data;
using LexiconLMSBlazor.Server.Models;
using LexiconLMSBlazor.Shared.Dtos;

namespace LexiconLMSBlazor.Server.Controllers
{
    [Route("api/Acttype")]
    [ApiController]
    public class ActivityTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActivityTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityTypeDto>>> GetActivityType()
        {
            if (_context.ActivityType == null)
            {
                return BadRequest();
            }

            var dto = _context.ActivityType
                .Select(d => new ActivityTypeDto
                {
                    Id = d.Id,
                    Name = d.Name
                });

            return await dto.ToListAsync();
        }

        //// GET: api/ActivityTypes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ActivityType>> GetActivityType(int id)
        //{
        //  if (_context.ActivityType == null)
        //  {
        //      return NotFound();
        //  }
        //    var activityType = await _context.ActivityType.FindAsync(id);

        //    if (activityType == null)
        //    {
        //        return NotFound();
        //    }

        //    return activityType;
        //}

        // PUT: api/ActivityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityType(int id, ActivityType activityType)
        {
            if (id != activityType.Id)
            {
                return BadRequest();
            }

            _context.Entry(activityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTypeExists(id))
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

        // POST: api/ActivityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityType>> PostActivityType(ActivityType activityType)
        {
          if (_context.ActivityType == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ActivityType'  is null.");
          }
            _context.ActivityType.Add(activityType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityType", new { id = activityType.Id }, activityType);
        }

        // DELETE: api/ActivityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityType(int id)
        {
            if (_context.ActivityType == null)
            {
                return NotFound();
            }
            var activityType = await _context.ActivityType.FindAsync(id);
            if (activityType == null)
            {
                return NotFound();
            }

            _context.ActivityType.Remove(activityType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityTypeExists(int id)
        {
            return (_context.ActivityType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
