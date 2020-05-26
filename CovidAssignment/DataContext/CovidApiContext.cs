using CovidAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CovidAssignment.DataContext
{
    public class CovidApiContext : DbContext
    {
        //Create database and connection
        public CovidApiContext() : base("CovidApiConnection")
        {
            
        }

        //Return Global Table Data
        public DbSet<Global> Globals { get; set; }

        // Return CountryStatus Data
        public DbSet<CountryStatus> Countries { get; set; }

        //Return CountriesInfo Data
        public DbSet<Country> CountriesInfo { get; set; }

    }
}