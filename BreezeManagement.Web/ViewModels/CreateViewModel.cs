using System.ComponentModel.DataAnnotations;

namespace BreezeManagement.Web.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        public string CreationNumber { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public string VehicleName { get; set; }

        [Required]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "Price has to be greater than 0")]
        public double VehiclePrice { get; set; }
    }
}
