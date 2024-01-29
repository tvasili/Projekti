﻿using Microsoft.EntityFrameworkCore;
using MyUniversity.Data.Models;

namespace MyUniversity.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<University> Universities { get; set; }
    }
}
