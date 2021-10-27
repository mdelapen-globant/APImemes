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
        private readonly MemeService _memeService;
        public MemeController(MemeContext context, MemeService memeService)
        {
            _context = context;
            _memeService = memeService;
        }

        // GET: api/meme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemeImage>>> GetMemeImages()
        {
            return await _context.MemeImages.Include(c => c.Coordinates).ToListAsync();
        }



        [HttpGet("{memeId}")]
        //[Route("create")]
        public FileResult CreateMeme(int memeId, [FromBody] List<string> texts)
        {
            if(MemeImageExists(memeId))
            {
                string memePath = _memeService.CreateMeme(GetMemeById(memeId), GetCoordinatesById(memeId), texts);
                var image = System.IO.File.OpenRead(memePath);
                return File(image, "image/jpg");
            }
            else
            {
                throw new Exception("Meme not found");
            }
            
        }

        private List<TextCoordinates> GetCoordinatesById(int id)
        {
            var meme = _context.MemeImages.Where(m => m.Id == id).Include(c => c.Coordinates).ToList();
            return meme[0].Coordinates.ToList(); //return the coordinates for a given meme id
        }

        private MemeImage GetMemeById(int id)
        {
            var meme = _context.MemeImages.Find(id);
            return meme;
        }
        private bool MemeImageExists(int id)
        {
            return _context.MemeImages.Any(e => e.Id == id);
        }

    }
}
