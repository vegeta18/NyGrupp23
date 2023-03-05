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
        public DbSet<Böcker> Böckers { get; set; }
        public DbSet<Bokning> Bokningar { get; set; }
        public DbSet<Expidit> Expiditer { get; set; }
        public DbSet<Faktura> Fakturor { get; set; }
        public DbSet<Medlem> Medlemmar { get; set; }

        public BibliotekContext() { }
        
        public Seed seed = new Seed();
        public void Reset()
        {
            using (SqlConnection con = new SqlConnection(Database.Connection.ConnectionString))
            using (SqlCommand scmd = new SqlCommand("DECLARE @SQL VARCHAR(MAX)='' SELECT @SQL = @SQL + 'ALTER TABLE ' + .....", con) ) // Här måste den kopplas till databasen
            {
                con.Open();
                for(int i = 0; i < 5; i++)
                {
                    try
                    {
                        scmd.ExecuteNonQuery();  
                    }
                    catch(System.Exception)
                    {

                    }

                }
                con.Close();    
            }
            Database.Initialize(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }


    }
}