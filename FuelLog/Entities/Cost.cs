using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Entities
{
    public class Cost
    {
        [Key]
        public int Id { get; set; }
        public string Note { get; set; }
        [Required]
        public string Title { get; set; }
        public int Costs { get; set; }
        public int OdoCounter { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
