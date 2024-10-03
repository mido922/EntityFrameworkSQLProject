using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSQLProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<toDoTask> toDoTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;Database=toDoTaskDB;username=postgres;password=1234");
        }
    }
}