using FuelLog.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLog.Contexts
{
    public class FuelContext : IdentityDbContext
    {
        public FuelContext(DbContextOptions<FuelContext> options) : base(options)
        {

        }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Cost> Costs { get; set; }

    }
}
