   


namespace Dispatch_app.Models
{
    public class DriverResponse
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CarrierId { get; set; }
        public List<Contacts> Contacts { get; set; }
    }
}
