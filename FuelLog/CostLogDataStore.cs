using FuelLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog
{
    public class CostLogDataStore
    {
        public static CostLogDataStore Current { get; } = new CostLogDataStore();
        public List<CostLog> Costs { get; set; }

        public CostLogDataStore()
        {
            Costs = new List<CostLog>()
            {
                new CostLog()
                {
                    Id = 1,
                    Name = "Gumi",
                    Description = "Promena na gumi",
                    Cost = "100"
                },
                new CostLog()
                {
                    Id = 2,
                    Name = "Kaisi",
                    Description = "Promena na kais",
                    Cost = "200"
                },
                new CostLog()
                {
                    Id = 3,
                    Name = "Staklo",
                    Description = "Promena na staklo",
                    Cost = "100"
                }
            };
        }
    }
}
