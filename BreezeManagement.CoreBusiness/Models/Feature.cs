﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.CoreBusiness.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }

        [Required]
        public string FeatureName { get; set; }

        [Required]
        public string? Description { get; set; }

        public double AddedPrice { get; set; }

        public List<VehicleFeature> VehicleFeatures { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
