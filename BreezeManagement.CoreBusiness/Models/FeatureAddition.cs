using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.CoreBusiness.Models
{
    public class FeatureAddition
    {
        public int FeatureAdditionId { get; set; }

        [Required]
        public int FeatureId { get; set; }

        public double? UnitPrice { get; set; }

        public Feature Feature { get; set; }
    }
}
