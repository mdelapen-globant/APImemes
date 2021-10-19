using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class MemeImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<TextCoordinates> Coordinates { get; set; }
    }
}