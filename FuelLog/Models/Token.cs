using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Models
{
    public class Token
    {
        public string token { get; set; }
        public string expiration { get; set; }
        public string currentTime { get; set; }
    }
}
