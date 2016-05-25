using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2_5.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MemberId { get; set; }
        public string Address { get; set; }
        public string AreaCode { get; set; }
        public string City { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$")]
        public string Email { get; set; }

        public virtual ICollection<Vehicle> MyVehicles { get; set; }
    }
}