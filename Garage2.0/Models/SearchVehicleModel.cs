using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2._0.Models
{
    public class SearchVehicleModel
    {
        public VehicleTypes? Type { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]{1,8}$")]
        public string RegNumber { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int? NumOfWheels { get; set; }

        public DateTime? CheckInTime { get; set; }
    }
}
