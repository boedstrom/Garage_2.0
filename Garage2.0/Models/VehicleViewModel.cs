using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2_5.Models
{
    public class VehicleViewModel
    {
        [Required]
        public List<VehicleType> VehicleTypes { get; set; }
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
        public IEnumerable<Member> Members { get; set; }
    }
}