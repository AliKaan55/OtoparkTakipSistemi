using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkTakipSistemi.Core
{
    public class Tariff
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TariffName { get; set; } 

        [Required]
        public decimal BasePrice { get; set; }

        [Required]
        public decimal HourlyPrice { get; set; } 
    }
}
