using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Dispatch_app.Models
{
    public class Trailers
    {

        [Key]
        public int Id { get; set; }    
        public string TrailerType { get; set; } //maybe we have different ones (flatbed, refrigerated, dry van etc )

        public string TrailerWidth { get; set; }  // we might different sizes for out tarilers and different trucks might be well
                                                  // equiped for certain trailers and their weights 

        public string TrailerLoadCapacity { get; set; }  
        public string TrailerVinNumber { get; set; }
      
    }
}
