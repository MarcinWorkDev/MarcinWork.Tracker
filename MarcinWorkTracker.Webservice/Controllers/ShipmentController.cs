using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarcinWorkTracker.Logic.Services;
using MarcinWorkTracker.Logic.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace MarcinWorkTracker.Webservice.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]/[action]")]
    public class ShipmentController : Controller
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentController(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_shipmentRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_shipmentRepository.GetOne(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody]Shipment shipment)
        {
            _shipmentRepository.Add(shipment);
            return CreatedAtAction("Get", new { shipment.ShipmentId }, shipment);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody]JsonPatchDocument<Shipment> shipmentPatch)
        {
            Shipment shipment = _shipmentRepository.GetOne(id);
            if (shipment == null)
            {
                NotFound();
            }

            shipmentPatch.ApplyTo(shipment);

            _shipmentRepository.Update(shipment);
            return Ok();
        }
    }
}