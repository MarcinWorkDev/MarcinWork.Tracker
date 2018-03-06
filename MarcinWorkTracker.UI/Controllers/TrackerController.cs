using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarcinWorkTracker.Logic.Services;

namespace MarcinWorkTracker.Controllers
{
    [Route("[controller]/[action]")]
    public class TrackerController : Controller
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly ITrackingRepository _trackingRepository;

        public TrackerController(IShipmentRepository shipmentRepository, ITrackingRepository trackingRepository)
        {
            _shipmentRepository = shipmentRepository;
            _trackingRepository = trackingRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrackList()
        {
            return View(_trackingRepository.TrackAll());
        }
        public IActionResult TrackList2()
        {
            return View(_trackingRepository.GetAll());
        }
    }
}