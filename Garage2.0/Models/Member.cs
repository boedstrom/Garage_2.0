using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2._0.Models
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
        public string Email { get; set; }
    }
}