namespace Garage2_5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2_5.DataAccessLayer.VehiclesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Garage2_5.DataAccessLayer.VehiclesContext context)
        {
            VehicleType[] vTypes = new[]
            {
                new VehicleType { Name = "Car" },
                new VehicleType { Name = "Van" },
                new VehicleType { Name = "Pickup" },
                new VehicleType { Name = "Truck" },
                new VehicleType { Name = "Bus" },
                new VehicleType { Name = "MC" }
            };
            context.VehicleTypes.AddOrUpdate(v => v.Name, vTypes);
            context.SaveChanges();

            Member[] members = new[]
            {
              new Member { Name = "Andrew Peters", MemberId = 123456, Address = "1st Street", AreaCode = "12345", City = "Shitsville", Phone = "555-555-5551", Email = "andrew.peters@gmail.com" },
              new Member { Name = "Brice Lambson", MemberId = 123457, Address = "2nd Street", AreaCode = "12346", City = "Shitsville", Phone = "555-555-5552", Email = "brice.lambson@gmail.com" },
              new Member { Name = "Rowan Miller", MemberId = 123458, Address = "3rd Street", AreaCode = "12347", City = "Shitsville", Phone = "555-555-5553", Email = "rowan.miller@gmail.com" }
            };
            context.Members.AddOrUpdate(m => m.Name, members);
            context.SaveChanges();
        }
    }
}
