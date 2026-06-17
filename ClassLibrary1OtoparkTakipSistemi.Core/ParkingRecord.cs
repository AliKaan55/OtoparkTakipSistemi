using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkTakipSistemi.Core
{
    public class ParkingRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string LicensePlate { get; set; } 

        [Required]
        public VehicleType VehicleType { get; set; } 

        [Required]
        public int ParkingSlotId { get; set; } 

        public virtual ParkingSlot ParkingSlot { get; set; }

        [Required]
        public DateTime CheckInTime { get; set; } = DateTime.Now; 

        public DateTime? CheckOutTime { get; set; } 

        public decimal TotalPrice { get; set; } = 0; 

        public bool IsActive { get; set; } = true; 
    }
}
