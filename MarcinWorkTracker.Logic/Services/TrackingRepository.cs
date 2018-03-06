using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcinWorkTracker.Logic.Models;
using MarcinWorkTracker.Logic.Data;
using MarcinWorkTracker.Logic.Services.Providers;
using Microsoft.EntityFrameworkCore;

namespace MarcinWorkTracker.Logic.Services
{
    public class TrackingRepository : ITrackingRepository
    {
        private readonly MWTrackerDbContext _context;

        public TrackingRepository(MWTrackerDbContext context)
        {
            _context = context;
        }

        public Tracking Add(Tracking tracking)
        {
            _context.Tracking.Add(tracking);
            _context.SaveChanges();
            return tracking;
        }
        public Tracking Update(Tracking tracking)
        {
            _context.Tracking.Update(tracking);
            _context.SaveChanges();
            return tracking;
        }

        public IQueryable<Tracking> GetAll()
        {
            return _context.Tracking.OrderByDescending(e => e.LastCheckTimestamp);
        }

        public IQueryable<Tracking> GetAllByShipment(int shipmentId)
        {
            return _context.Tracking.Where(e => e.ShipmentId == shipmentId);
        }

        public Tracking GetOne(String trackingNumber)
        {
            return _context.Tracking.FirstOrDefault(e => e.TrackingNumber == trackingNumber);
        }

        public TrackingStatus TrackOne(string trackingNumber)
        {
            return TrackByProvider(_context.Tracking.Include(pc => pc.ProviderCompany).Include(sh => sh.Shipment).Where(w => w.TrackingNumber == trackingNumber).FirstOrDefault());
        }

        public IQueryable<TrackingStatus> TrackAll()
        {
            List<TrackingStatus> trackingStatusList = new List<TrackingStatus>();

            foreach (Tracking tracking in _context.Tracking.Include(pc => pc.ProviderCompany).Include(sh => sh.Shipment))
            {
                trackingStatusList.Add(TrackByProvider(tracking));
            }
            return trackingStatusList.AsQueryable();
        }

        private TrackingStatus TrackByProvider(Tracking tracking)
        {
            TrackingStatus trackingStatus = new TrackingStatus();
            trackingStatus.tracking = tracking;

            try
            {
                ITrackProvider trackProvider = (ITrackProvider)(Activator.CreateInstance(Type.GetType(tracking.ProviderCompany.ProviderCompanyServiceClassName)));
                trackProvider.Track(tracking.TrackingNumber);
                trackingStatus.jsonStatus = trackProvider.ToJson();
            }
            catch (Exception ex)
            {
                trackingStatus.jsonStatus = "{IS_ERROR = true, ERROR = " + ex.Message + "}";
            }
            return trackingStatus;
        }
    }
}
