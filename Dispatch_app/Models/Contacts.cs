using System.ComponentModel.DataAnnotations;

namespace Dispatch_app.Models
{
    public class Contacts
    {
        [Key]
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int? DriverId { get; set; }
         
        
    }
}
