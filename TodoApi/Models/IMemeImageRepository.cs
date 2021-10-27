using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public interface IMemeImageRepository
    {
        MemeImage GetMemeImage(int id);
        IEnumerable<MemeImage> GetAllMemeImages();
        MemeImage CreateMemeImage(MemeImage memeImage);
        List<TextCoordinates> GetTextCoordinates(int memeId);
    }
}
