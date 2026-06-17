using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkTakipSistemi.Core
{
    public class ParkingSlot
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string SlotNumber { get; set; } 

        [Required]
        [StringLength(20)]
        public string Floor { get; set; } 

        
        [Required]
        public int Capacity { get; set; } = 1;

        
        public int OccupiedCount { get; set; } = 0;

        
        [NotMapped]
        public int AvailableCount => Capacity - OccupiedCount;

        [NotMapped]
        public bool IsFull => OccupiedCount >= Capacity;

        
        [NotMapped]
        public string DisplayText => $"{SlotNumber} ({AvailableCount}/{Capacity} boş)";
    }
}
