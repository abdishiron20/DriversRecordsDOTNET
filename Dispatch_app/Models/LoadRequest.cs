namespace Dispatch_app.Models
{
    public class LoadRequest
    {

        public int Id { get; set; }
        public string PickupDate { get; set; }

        public string Description { get; set; }
        public string DeliveryDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CostForLoad { get; set; }

        public LoadStatus Status { get; set; }
       


          //  public string driverID { get; set;}
          // public string CoDriverId { get; set; }
          //public string TractorId { get; set; }

    }
}
