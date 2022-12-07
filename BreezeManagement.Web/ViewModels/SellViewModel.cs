using System.ComponentModel.DataAnnotations;

namespace BreezeManagement.Web.ViewModels
{
    public class SellViewModel
    {
        [Required]
        public string SalesOrderNumber { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public string VehicleName { get; set; }

        public double VehiclePrice { get; set; }
    }
}
