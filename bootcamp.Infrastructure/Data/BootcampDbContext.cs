using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bootcamp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace bootcamp.Infrastructure.Data
{
    public class BootcampDbContext: DbContext
    {
        public BootcampDbContext(DbContextOptions<BootcampDbContext>options): base(options)
        {
            
        }
        public DbSet<Applicants> Applicants { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}