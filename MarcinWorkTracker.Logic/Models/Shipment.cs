using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcinWorkTracker.Logic.Models
{
    public class Shipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShipmentId { get; set; }
        [Required]
        public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }
        [Required]
        public string OrderName { get; set; }
        public string OrderNote { get; set; }
        public string OrderUrl { get; set; }
        
        public virtual IEnumerable<Tracking> Trackings { get; set; }
    }
}
