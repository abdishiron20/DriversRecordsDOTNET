using System.ComponentModel.DataAnnotations;

namespace Dispatch_app.Models
{
    public class DriverRequest
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set;  }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set;  }
        public string Address { get; set;  }
        public string Phone { get; set;  }
        public string Email { get; set;  }
        public List<Contacts> Contacts { get; set; }

    }
}
