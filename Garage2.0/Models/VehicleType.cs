using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2_5.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}