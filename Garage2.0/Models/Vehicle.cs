using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public VehicleTypes Type { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{1,8}$")]
        public string RegNumber { get; set; }
        [Required]
        public string Color { get; set; } = "white";
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int NumOfWheels { get; set; } = 4;
        public DateTime CheckInTime { get; set; } = DateTime.Now;
    }
}