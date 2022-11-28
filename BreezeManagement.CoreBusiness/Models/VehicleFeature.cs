﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.CoreBusiness.Models
{
    public class VehicleFeature
    {
        public int VehicleId { get; set; }

        public Vehicle? Vehicle { get; set; }

        public int FeatureId { get; set; }

        public Feature? Feature { get; set; }
    }
}
