using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcinWorkTracker.Logic.Models
{
    public class ProviderCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProviderCompanyId { get; set; }

        [Required]
        public string ProviderCompanyName { get; set; }

        public string ProviderCompanyServiceClassName { get; set; } 
    }
}
