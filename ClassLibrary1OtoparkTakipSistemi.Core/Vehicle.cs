using OtoparkTakipSistemi.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkTakipSistemi.Core
{
    public enum VehicleType
    {
        Otomobil = 1,  
        Motorsiklet = 2,  
        Kamyon = 3,       
        Otobüs = 4          
    }

public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
