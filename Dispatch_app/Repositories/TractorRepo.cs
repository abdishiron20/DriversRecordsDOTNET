using Dispatch_app.Models;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;

namespace Dispatch_app.Repositories
{
    public class TractorRepo: ITractorRepo
    {

        public AppDbContext _dbContext;

        public TractorRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TractorResponse> GetTractor(int id)
        {


            Tractors tractorResult = await _dbContext.Tractors.Where(x => x.id == id).FirstOrDefaultAsync();

            TractorResponse response = new TractorResponse();


            response.Make = tractorResult.Make;
            response.Model = tractorResult.Model;
            response.YearMade = tractorResult.YearMade;
            response.VinNumber = tractorResult.VinNumber;
            

       

            return response;
        }



        public async Task<List<TractorResponse>> GetTractors()
        {

            List<TractorResponse> tractorResponses = new List<TractorResponse>();
           
 
            var tractorResult = await _dbContext.Tractors.ToListAsync();
            foreach (Tractors tractor in tractorResult)
            {
                TractorResponse tractorResponse = new TractorResponse();

                tractorResponse.Make = tractor.Make;
                tractorResponse.YearMade = tractor.YearMade;
                tractorResponse.Model = tractor.Model;
                tractorResponse.YearMade = tractor.YearMade;


                tractorResponses.Add(tractorResponse);
            }

            return tractorResponses;
        }

        public async Task<string> Create(TractorRequest request)
        {

            string error = string.Empty;
            if (string.IsNullOrEmpty(request.Make))
            {
                return "Sorry tractor make can not be null";
            }
            Tractors tractorsObj = new Tractors();

            tractorsObj.Make= request.Make; 
            tractorsObj.Model = request.Model;
            tractorsObj.YearMade = request.YearMade;
            tractorsObj.VinNumber = request.VinNumber;
           // tractorsObj.id = request.ID;
          

            _dbContext.Tractors.Add(tractorsObj);
            _dbContext.SaveChanges();

            error = "your data has been saved successfully!";

            return error;
        }


        public async Task<string> Update(TractorRequest request)
        {
            var tractor = _dbContext.Tractors.Where(x => x.id == request.ID).FirstOrDefault(); //

            if (tractor == null)
            {
                return "Sorry, the ID you provided does not exist!";
            }
            tractor.Make = request.Make;
            tractor.Model = request.Model;
            tractor.YearMade = request.YearMade;
            tractor.VinNumber = request.VinNumber;
           

            _dbContext.Tractors.Update(tractor);
            _dbContext.SaveChanges();

            return "your data has been updated successfully!";
        }

        public async Task<string> Delete(int id)
        {
            var data = _dbContext.Tractors.Where(x => x.id == id).FirstOrDefault();

            if (data == null)
            {
                return "sorry, the Id you provided does not exist!";
            }

            _dbContext.Tractors.Remove(data);
            _dbContext.SaveChanges();

            return "your data has been deleted successfully!";
        }

}
}
