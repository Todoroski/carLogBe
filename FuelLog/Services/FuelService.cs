using FuelLog.Contexts;
using FuelLog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Services
{
    public class FuelService : IFuelRepository
    {
        private readonly FuelContext _context;

        public FuelService(FuelContext context)
        {
            _context = context;
        }

        public IEnumerable<Fuel> GetFuels()
        {
            return _context.Fuels.OrderBy(x => x.Id).ToList();
        }

        public Fuel GetFuel(int id)
        {
            return _context.Fuels.Where(x => x.Id == id).FirstOrDefault();
        }

        public Fuel UpdateFuel(int id, Fuel fuel)
        {
            var fuelLog = _context.Fuels.FirstOrDefault(x => x.Id == id);

            if(fuelLog != null)
            {
                fuelLog.FuelLiters = fuel.FuelLiters;
                fuelLog.Price = fuel.Price;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("Not found");
            }
            
            return fuel;
        }

        public void AddFuel(Fuel fuel)
        {
            _context.Fuels.Add(fuel);
            _context.SaveChanges();
        }

        public void DeleteFuel(int id)
        {
            var fuelLog = _context.Fuels.FirstOrDefault(x => x.Id == id);

            if(fuelLog == null)
            {
                throw new ArgumentNullException("Not Found");
            }

            _context.Fuels.Remove(fuelLog);
            _context.SaveChanges();
        }
    }
}
