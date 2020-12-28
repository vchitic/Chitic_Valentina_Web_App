using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chitic_Valentina_Web_App.Models;

namespace Chitic_Valentina_Web_App.Data
{
    public class Chitic_Valentina_Web_AppContext : DbContext
    {
        public Chitic_Valentina_Web_AppContext (DbContextOptions<Chitic_Valentina_Web_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Chitic_Valentina_Web_App.Models.Plant> Plant { get; set; }

        public DbSet<Chitic_Valentina_Web_App.Models.Weather> Weather { get; set; }

        public DbSet<Chitic_Valentina_Web_App.Models.Category> Category { get; set; }

        public DbSet<Chitic_Valentina_Web_App.Models.Watering> Watering { get; set; }

        //public DbSet<Chitic_Valentina_Web_App.Models.Category> Category { get; set; }
    }
}
