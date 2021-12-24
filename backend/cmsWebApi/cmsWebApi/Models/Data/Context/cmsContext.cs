using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsWebApi.models.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace cmsWebApi.models.Data.context
{
    public class cmsContext : DbContext
    {
        public cmsContext(DbContextOptions<cmsContext> options): base(options) {}

        public DbSet<Student> Student { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Subjects> Subjects { get; set; } 
        public DbSet<Teacher> Teacher { get; set; }
    }
}