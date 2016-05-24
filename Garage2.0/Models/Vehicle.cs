using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage2_5.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{1,8}$")]
        public string RegNumber { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        public int NumOfWheels { get; set; } = 4;
        public DateTime CheckInTime { get; set; } = DateTime.Now;

        public virtual VehicleType VehicleType { get; set; }
        public virtual Member Member { get; set; }
    }
}
