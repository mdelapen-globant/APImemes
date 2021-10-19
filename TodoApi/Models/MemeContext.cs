using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class MemeContext : DbContext
    {
        public MemeContext(DbContextOptions<MemeContext> options)
            : base(options)
        {
        }

        public DbSet<MemeImage> MemeImages { get; set; }
    }
}