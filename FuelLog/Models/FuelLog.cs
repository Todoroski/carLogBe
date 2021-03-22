using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Models
{
    public class FuelLog
    {
        public int Id { get; set; }
        public string FuelLiters { get; set; }
        public string Price { get; set; }
    }
}
