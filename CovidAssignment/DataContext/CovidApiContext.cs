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
        public CovidApiContext() : base("CovidApiConnection")
        {
            
        }

        public DbSet<Global> Globals { get; set; }

        public DbSet<CountryStatus> Countries { get; set; }

        public DbSet<Country> CountriesInfo { get; set; }

    }
}