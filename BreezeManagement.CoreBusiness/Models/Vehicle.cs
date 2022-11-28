﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.CoreBusiness.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Required]
        public string Registration { get; set; }

        [Required]
        public string ModelName { get; set; }

        [Required]
        public string Colour { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime DateOfManufacture { get; set; }

        public int NumberOfOwners { get; set; }

        public double Mileage { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<VehicleFeature>? VehicleFeatures { get; set; }
    }
}