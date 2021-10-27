using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class SQLMemeImagesRepository : IMemeImageRepository
    {
        private readonly MemeContext context;
        public SQLMemeImagesRepository(MemeContext context)
        {
            this.context = context;
        }
        
        public MemeImage CreateMemeImage(MemeImage memeImage)
        {
            context.MemeImages.Add(memeImage);
            context.SaveChanges();
            return memeImage;

        }

        public IEnumerable<MemeImage> GetAllMemeImages()
        {
            return context.MemeImages;
        }

        public MemeImage GetMemeImage(int id)
        {
            return context.MemeImages.Find(id);
        }

        public List<TextCoordinates> GetTextCoordinates(int memeId)
        {
            var meme = context.MemeImages.Where(m => m.Id == memeId).Include(c => c.Coordinates).ToList();
            return meme[0].Coordinates.ToList(); //return the coordinates for a given meme id
        }
    }
}
