using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2._0.Models
{
    public enum VehicleTypes
    {
        Car = 1,
        Van,
        Truck
    }

    public class Vehicle
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumOfWheels { get; set; }
        public string CheckInTime { get; set; } = DateTime.Now.ToString();
    }
}