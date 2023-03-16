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
        public string VehicleRegistration { get; set; }

        public double VehiclePrice { get; set; }
    }
}
