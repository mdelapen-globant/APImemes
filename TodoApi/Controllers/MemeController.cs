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
    public class MemeController : ControllerBase
    {
        private readonly MemeContext _context;
        public MemeController(MemeContext context)
        {
            _context = context;
        }

        // GET: api/meme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemeImage>>> GetMemeImages()
        {
            return await _context.MemeImages.ToListAsync();
        }

        //GET: api/meme/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemeImage>> GetMemeImage(long id)
        {
            var memeImage = await _context.MemeImages.FindAsync(id);

            if (memeImage == null)
            {
                return NotFound();
            }

            return memeImage;
        }

        // PUT: api/meme/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemeImage(int id, MemeImage memeImage)
        {
            if (id != memeImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(memeImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemeImageExists(id))
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

        // POST: api/meme
        [HttpPost]
        public async Task<ActionResult<MemeImage>> PostMemeImage(MemeImage memeImage)
        {
            _context.MemeImages.Add(memeImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMemeImage), new { id = memeImage.Id }, memeImage);
        }

        // DELETE: api/meme/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemeImage(int id)
        {
            var items = await _context.MemeImages.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }

            _context.MemeImages.Remove(items);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemeImageExists(int id)
        {
            return _context.MemeImages.Any(e => e.Id == id);
        }

    }
}
