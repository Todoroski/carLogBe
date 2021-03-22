using FuelLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog
{
    public class FuelDataStore
    {
        public static FuelDataStore Current { get; } = new FuelDataStore();
        public List<Models.FuelLog> Fuels { get; set; }

        public FuelDataStore()
        {
            Fuels = new List<Models.FuelLog>()
            {
                new Models.FuelLog()
                {
                    Id = 1,
                    FuelLiters = "5.5",
                    Price = "25"
                },
                new Models.FuelLog()
                {
                    Id = 2,
                    FuelLiters = "10",
                    Price = "50"
                },
                new Models.FuelLog()
                {
                    Id = 3,
                    FuelLiters = "15",
                    Price = "75"
                }
            };
        }
    }
}
