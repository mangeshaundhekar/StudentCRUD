using Microsoft.EntityFrameworkCore;
using SimpleCrudDemo.Models;
using StudentCRUD.Models;
using System.Collections.Generic;

namespace SimpleCrudDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
