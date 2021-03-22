using FuelLog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Services
{
    public interface ICostRepository
    {
        IEnumerable<Cost> GetCosts();
        Cost GetCost(int id);
        void AddCost(Cost cost);
        void UpdateCost(Cost cost);
        void DeleteCost(int id);
    }
}
