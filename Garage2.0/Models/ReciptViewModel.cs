using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2._0.Models
{
    public class ReciptViewModel
    {
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public string RegNumber { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

        public string CheckInTimeView {
            get {
                return CheckInTime.ToString("yyyy-MM-dd HH:mm");
            }
        }

        public string CheckOutTimeView {
            get {
                return CheckOutTime.ToString("yyyy-MM-dd HH:mm");
            }
        }

        public TimeSpan ParkingTime { get; set; }
        public string ParkTimeString { get; set; }
        public int ParkingFee { get; set; }
        public Decimal TotalParkingFee { get; set; }
    }
}