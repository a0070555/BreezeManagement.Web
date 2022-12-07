using System.ComponentModel.DataAnnotations;

namespace BreezeManagement.Web.ViewModels
{
    public class AddViewModel
    {
        [Required]
        public int FeatureId { get; set; }

        [Required]
        public string FeatureName { get; set; }

        [Required]
        public double FeaturePrice { get; set; }
    }
}
