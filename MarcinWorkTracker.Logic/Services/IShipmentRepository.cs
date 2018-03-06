using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcinWorkTracker.Logic.Models;

namespace MarcinWorkTracker.Logic.Services
{
    public interface IShipmentRepository
    {
        Shipment GetOne(int shipmentId);
        IQueryable<Shipment> GetAll();
        Shipment Add(Shipment shipment);
        Shipment Update(Shipment shipment);
    }
}
