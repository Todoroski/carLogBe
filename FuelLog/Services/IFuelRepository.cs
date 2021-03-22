using FuelLog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Services
{
    public interface IFuelRepository
    {
        IEnumerable<Fuel> GetFuels();
        Fuel GetFuel(int id);
        Fuel UpdateFuel(int id, Fuel fuel);
        void AddFuel(Fuel fuel);
        void DeleteFuel(int id);
    }
}
