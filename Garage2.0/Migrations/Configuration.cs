namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2._0.DataAccessLayer.VehiclesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Garage2._0.DataAccessLayer.VehiclesContext context)
        {
            string currCheckIn = DateTime.Now.ToString();

            //  This method will be called after migrating to the latest version.
            context.Vehicles.AddOrUpdate(r => r.RegNumber,
                new Vehicle { Type = (int)VehicleTypes.Car, RegNumber = "ABC123", Color = "Black", Brand = "Volvo", Model = "V70", NumOfWheels = 4, CheckInTime = currCheckIn },
                new Vehicle { Type = (int)VehicleTypes.Car, RegNumber = "DEF456", Color = "Silver", Brand = "BMW", Model = "M5", NumOfWheels = 4, CheckInTime = currCheckIn },
                new Vehicle { Type = (int)VehicleTypes.Van, RegNumber = "GHI789", Color = "White", Brand = "Ford", Model = "Ecoline", NumOfWheels = 4, CheckInTime = currCheckIn },
                new Vehicle { Type = (int)VehicleTypes.Truck, RegNumber = "AAA666", Color = "White", Brand = "Scania", Model = "R730", NumOfWheels = 10, CheckInTime = currCheckIn });
        }
    }
}
