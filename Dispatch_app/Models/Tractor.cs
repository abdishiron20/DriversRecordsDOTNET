using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Dispatch_app.Models
{
    public class Tractor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Make is required.")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Year Made is required.")]
        public string YearMade { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "VIN Number is required.")]
        public string VinNumber { get; set; }

    }
}
