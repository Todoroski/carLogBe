using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Entities
{
    public class Fuel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FuelLiters { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public int OdoCounter { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal AvgConsumption { get; set; }
        [Required]
        public int Cost { get; set; }
    }
}
