using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Modellager;

namespace Datalager
{
    public class BibliotekContext : DbContext
    {

        //INTE KLAR SE KOMMENTAR
        public DbSet<Böcker> Böckers { get; set; } = null!;
        public DbSet<Bokning> Bokningar { get; set; } = null!;
        public DbSet<Expidit> Expiditer { get; set; } = null!;
        public DbSet<Faktura> Fakturor { get; set; } = null!;
        public DbSet<Medlem> Medlemmar { get; set; } = null!;

        public BibliotekContext() { }
        
        public BibliotekContext(DbContextOptions<BibliotekContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                    string connectionString = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build()
                    .GetConnectionString("Pizzaria");
                    optionsBuilder.UseSqlServer(connectionString);
                
            }
        }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }


    }
}