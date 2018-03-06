using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcinWorkTracker.Logic.Models;
using MarcinWorkTracker.Logic.Data;
using Microsoft.EntityFrameworkCore;

namespace MarcinWorkTracker.Logic.Services
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly MWTrackerDbContext _context;

        public ShipmentRepository(MWTrackerDbContext context)
        {
            _context = context;
        }

        public IQueryable<Shipment> GetAll()
        {
            return _context.Shipment.Include(e => e.Trackings).ThenInclude(e => e.ProviderCompany).OrderByDescending(e => e.ShipmentId);
        }

        public Shipment GetOne(int ShipmentId)
        {
            return _context.Shipment.FirstOrDefault(e => e.ShipmentId == ShipmentId);
        }

        public Shipment Add(Shipment shipment)
        {
            _context.Shipment.Add(shipment);
            _context.SaveChanges();
            return shipment;
        }
        public Shipment Update(Shipment shipment)
        {
            _context.Shipment.Update(shipment);
            _context.SaveChanges();
            return shipment;
        }
    }
}
