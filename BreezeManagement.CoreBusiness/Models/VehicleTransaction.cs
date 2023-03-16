using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.CoreBusiness.Models
{
    public class VehicleTransaction
    {
        public int VehicleTransactionId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public string? CreationNumber { get; set; }

        public string? SalesOrderNumber { get; set; }

        public double? UnitPrice { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public string DoneBy { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
