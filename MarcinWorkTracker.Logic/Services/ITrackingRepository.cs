using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcinWorkTracker.Logic.Models;

namespace MarcinWorkTracker.Logic.Services
{
    public interface ITrackingRepository
    {
        Tracking GetOne(string trackingNumber);
        IQueryable<Tracking> GetAll();
        Tracking Add(Tracking tracking);
        Tracking Update(Tracking tracking);
        IQueryable<Tracking> GetAllByShipment(int shipmentId);
        IQueryable<TrackingStatus> TrackAll();
        TrackingStatus TrackOne(string trackingNumber);
    }
}
