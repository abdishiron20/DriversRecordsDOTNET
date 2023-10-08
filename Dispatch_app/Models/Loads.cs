namespace Dispatch_app.Models
{
    public class Loads
    {
        public int Id { get; set; }
        public string PickupDate { get; set; }       //DateTime
        public string Description { get; set; }
        public string DeliveryDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CostForLoad { get; set; }
        public DateTime CreatedUTC { get; set; }  // ADD DATABASE
        public LoadStatus Status { get; set;} //adds from ader



        public int driverID { get; set; }
        public int CoDriverId { get; set; }
        public int TractorId { get; set; }

        //TODO: I need to assign 2 drivers (driver,co-driver) and a truck to one load as an end-point



    }
}
