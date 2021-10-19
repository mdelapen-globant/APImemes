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
    public class MemeController : Controller
    {
        private readonly IMemeImageRepository _memeImageRepository;

        public MemeController(IMemeImageRepository memeImageRepository)
        {
            _memeImageRepository = memeImageRepository;
        }

        public ViewResult Index()
        {
            var model = _memeImageRepository.GetAllMemeImages();
            return View(model);
        }

        //// GET: api/TodoItems
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MemeImage>>> GetMemeImages()
        //{
        //    return await _context.MemeImages.ToListAsync();
        //}

        // GET: api/memes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<MemeImage>> GetMemeImage(long id)
        //{
        //    var memeImage = await _context.MemeImages.FindAsync(id);

        //    if (memeImage == null)
        //    {
        //        return NotFound();
        //    }

        //    return memeImage;
        //}

        // POST: api/memes
        [HttpPost]
        public IActionResult PostMemeImage(MemeImage memeImage)
        {
            if(ModelState.IsValid)
            {
                MemeImage newMemeImage = _memeImageRepository.CreateMemeImage(memeImage);
            }
            return View();
        }

    }
}
