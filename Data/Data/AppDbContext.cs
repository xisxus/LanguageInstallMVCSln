using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageInstall.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace LanguageInstall.Data.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<Translation> Translation { get; set; }
        public DbSet<MainTable> MainTables { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            // Seed data from static class
            modelBuilder.Entity<MainTable>().HasData(SeedData.MainTables.ToArray());

            modelBuilder.Entity<Translation>().HasData(SeedData.Translations.ToArray());

        }

              
    }

}
        

