using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Garage2._0.DataAccessLayer
{
    public class VehiclesContext : DbContext
    {
        public DbSet<Models.Vehicle> Vehicles { get; set; }
        
        public VehiclesContext() : base("GarageDatabase")
        {
        }

        public System.Data.Entity.DbSet<Garage2._0.Models.ReciptViewModel> ReciptViewModels { get; set; }
    }
}