using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcinWorkTracker.Logic.Models
{
    public class Tracking
    {
        [Key]
        public string TrackingNumber { get; set; }
        public int ProviderCompanyId { get; set; }
        [ForeignKey("ProviderCompanyId")]
        public ProviderCompany ProviderCompany { get; set; }
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public DateTime LastCheckTimestamp { get; set; }
        public string LastCheckResult { get; set; }
        public Boolean Finished { get; set; }
    }
}
