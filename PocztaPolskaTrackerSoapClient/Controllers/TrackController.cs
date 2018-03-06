using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PocztaPolskaTrackerSoapClient.Models;

namespace PocztaPolskaTrackerSoapClient.Controllers
{
    public class TrackController : ApiController
    {
        public PocztaPolskaService.Przesylka Get(string id)
        {
            TrackerModel model = new TrackerModel();
            PocztaPolskaService.Przesylka przesylka = model.track(id);
            return przesylka;
        }
    }
}
