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
        }

        protected override void Seed(Garage2._0.DataAccessLayer.VehiclesContext context)
        {
            string currCheckIn = DateTime.Now.ToString();

            //  This method will be called after migrating to the latest version.
            context.Vehicles.AddOrUpdate(r => r.RegNumber,
                new Vehicle { Type = VehicleTypes.Car, RegNumber = "ABC123", Color = "black", Brand = "Volvo", Model = "V70", NumOfWheels = 4, CheckInTime = DateTime.Now },
                new Vehicle { Type = VehicleTypes.Car, RegNumber = "DEF456", Color = "silver", Brand = "BMW", Model = "M5", NumOfWheels = 4, CheckInTime = DateTime.Now },
                new Vehicle { Type = VehicleTypes.Van, RegNumber = "GHI789", Color = "white", Brand = "Ford", Model = "Ecoline", NumOfWheels = 4, CheckInTime = DateTime.Now },
                new Vehicle { Type = VehicleTypes.Truck, RegNumber = "AAA666", Color = "white", Brand = "Scania", Model = "R730", NumOfWheels = 10, CheckInTime = DateTime.Now });
        }
    }
}
