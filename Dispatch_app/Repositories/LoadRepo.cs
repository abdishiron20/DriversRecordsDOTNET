using Dispatch_app.Models;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using NuGet.Protocol.Plugins;

namespace Dispatch_app.Repositories
{
    public class LoadRepo : ILoadRepo
    {

        public AppDbContext _dbContext;

        public LoadRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoadResponse> GetLoad(int id)
        {


            Loads load = await _dbContext.Loads2.Where(x => x.Id == id).FirstOrDefaultAsync();


            var driver = await _dbContext.Drivers.Where(x => x.ID == load.driverID).FirstOrDefaultAsync();
            var coDriver = await _dbContext.Drivers.Where(x => x.ID == load.CoDriverId).FirstOrDefaultAsync();
           // var tractor = await _dbContext.Tractors.Where(x => x.id == load.TractorId).FirstOrDefaultAsync();

            LoadResponse response = new LoadResponse();


            response.CustomerEmail = load.CustomerEmail;
            response.CostForLoad= load.CostForLoad;
            response.CustomerEmail= load.CustomerEmail;
            response.Description = load.Description;
            response.PickupDate = load.PickupDate;
            response.DeliveryDate  = load.DeliveryDate;
            response.Id = load.Id;
            response.Status = load.Status;


            response.driver = new LoadDriver();
            response.driver.FirstName = driver.FirstName;
            response.driver.LastName = driver.LastName;
            response.driver.ID = driver.ID;

            response.CoDriver = new LoadDriver();
            response.CoDriver.FirstName = coDriver.FirstName;
            response.CoDriver.LastName = coDriver.LastName;
            response.CoDriver.ID = coDriver.ID;

            response.Tractor = new LoadTractor();
            response.Tractor.UnitId = 5; // tractor.id;


            return response;
        }



        public List<LoadResponse> GetLoads()
        {

            List<LoadResponse> loadResponses = new List<LoadResponse>();


            List<Loads> loadResult = _dbContext.Loads2.ToList();
            foreach (Loads load in loadResult)
            {
                LoadResponse loadResponse = new LoadResponse();

                loadResponse.PickupDate= load.PickupDate;
                loadResponse.DeliveryDate = load.DeliveryDate;
                loadResponse.CostForLoad   = load.CostForLoad;
                loadResponse.CustomerEmail= load.CustomerEmail;
                loadResponse.Description = load.Description;
                loadResponse.CustomerName = load.CustomerName;
                loadResponse.Id = load.Id;


                loadResponse.Status = load.Status; //status for loads


          


                loadResponses.Add(loadResponse);
            }

            return loadResponses;
        }

        public async Task<string> Create(LoadRequest request)
        {

            string error = string.Empty;
            if (string.IsNullOrEmpty(request.Description))
            {
                return "Sorry load Description  cannot be null";
            }
            Loads loadObj = new Loads();

            loadObj.Status = request.Status;
            loadObj.PickupDate = request.PickupDate;
            loadObj.DeliveryDate = request.DeliveryDate;
            loadObj.CostForLoad = request.CostForLoad;
            loadObj.CustomerEmail = request.CustomerEmail;  
            loadObj.Description = request.Description;
            loadObj.CustomerName = request.CustomerName;
            //loadObj.CreatedUTC = DateTime.UtcNow;   


            _dbContext.Loads2.Add(loadObj);
            _dbContext.SaveChangesAsync(); // changed 

            error = "your data has been saved successfully!";

            return error;
        }


        public async Task<string> Update(LoadRequest request)
        {
            var load = _dbContext.Loads2.Where(x => x.Id == request.Id).FirstOrDefault(); 

            if (load == null)
            {
                return "Sorry, the ID you provided does not exist!";
            }
            load.DeliveryDate = request.DeliveryDate;
            load.CostForLoad = request.DeliveryDate;

            load.CustomerEmail = request.CustomerEmail;
            load.Description = request.Description;
            load.CustomerName = request.CustomerName;
            load.CostForLoad = request.CostForLoad;
            load.CustomerName  = request.CustomerName;

            load.Status = request.Status;



            _dbContext.Loads2.Update(load);
            _dbContext.SaveChanges();

            return "your data has been updated successfully!";
        }

        public async Task<string> Delete(int id)
        {
            var data = _dbContext.Loads2.Where(x => x.Id == id).FirstOrDefault();

            if (data == null)
            {
                return "sorry, the Id you provided does not exist!";
            }

            _dbContext.Loads2.Remove(data);
            _dbContext.SaveChanges();

            return "your data has been deleted successfully!";
        }


        public async Task<string> LoadAssignment(int driverId, int coDriverId, int loadId, int tractorId)
        { 
            var load = await _dbContext.Loads2.Where(x => x.Id == loadId).FirstOrDefaultAsync();

        
            if (load == null)
            {
                return "Sorry this load does not exist";
            
            }
            load.driverID = driverId;   
            load.CoDriverId = coDriverId;   
            load.TractorId = tractorId;

            load.Status = LoadStatus.Assigned;

            _dbContext.Loads2.Update(load);
            _dbContext.SaveChanges();   

            return "dated saved successfully"; 
        }

        //loanUnassignment 
        //after unassigning, return it back to new
        //end of week - must able to view how many loads a certain truck pickedup 
        //        //end of week - must able to view how many loads a driver pickedup 

        // this endpoint will take 2 params -startingDate and endDate //same for both driver and truck 


        //1. LoadUnassignment(int driverId, int coDriverId, int loadId, int tractorId) and change Status.
        //2. Truck earnings: TruckEarnings(int TractorId, date StartDate, date EndDate)
        //e.g like:     var loadS = await _dbContext.Loads2.Where(x => x.TractorId == tractorId && x.PickupDate == StarDATE && x.DeliveryDate == eNDdate).tolist();
    }
}
