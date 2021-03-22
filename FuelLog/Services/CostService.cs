using FuelLog.Contexts;
using FuelLog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Services
{
    public class CostService : ICostRepository
    {
        private readonly FuelContext _context;

        public CostService(FuelContext context)
        {
            _context = context;
        }

        public IEnumerable<Cost> GetCosts()
        {
            return _context.Costs.OrderBy(x => x.Id).ToList();
        }

        public Cost GetCost(int id)
        {
            return _context.Costs.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddCost(Cost cost)
        {
            _context.Costs.Add(cost);
            _context.SaveChanges();
        }

        public void UpdateCost(Cost cost)
        {
            _context.Costs.Update(cost);
            _context.SaveChanges();
        }

        public void DeleteCost(int id)
        {
            var costLog = _context.Costs.FirstOrDefault(x => x.Id == id);

            if(costLog == null)
            {
                throw new ArgumentNullException("Not Found");
            }

            _context.Costs.Remove(costLog);
            _context.SaveChanges();
        }
    }
}
