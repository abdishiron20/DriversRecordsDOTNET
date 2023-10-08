using Dispatch_app.Models;
using Microsoft.EntityFrameworkCore;

namespace Dispatch_app.Repositories
{
    public class TrailerRepo : ITrailerRepo
    {
        public AppDbContext _dbContext;

        public TrailerRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TrailerResponse> GetTrailer(int id)
        {


          //  Trailers tractorResult = await _dbContext.Trailers.Where(x => x.id == id).FirstOrDefaultAsync();
            Trailers trailerResult = await _dbContext.Trailers.Where(x => x.Id == id).FirstOrDefaultAsync();

            TrailerResponse response = new TrailerResponse();




            response.TrailerType = trailerResult.TrailerType;
          //  response.TrailerVinNumber = tractorResult.TrailerVinNumber;
            response.TrailerWidth = trailerResult.TrailerWidth;
            response.TrailerLoadCapacity = trailerResult.TrailerLoadCapacity;
            response.TrailerVinNumber = trailerResult.TrailerVinNumber;
            response.id = trailerResult.Id;


            return response;
        }

        public List<TrailerResponse> GetTrailers()
        {

            List<TrailerResponse> trailerResponses = new List<TrailerResponse>();


            List<Trailers> trailerResult = _dbContext.Trailers.ToList();
            foreach (Trailers trailer in trailerResult)
            {
                TrailerResponse trailerResponse = new TrailerResponse();

                trailerResponse.TrailerVinNumber = trailer.TrailerVinNumber;
                trailerResponse.TrailerType = trailer.TrailerType;
                trailerResponse.TrailerWidth = trailer.TrailerWidth;
                trailerResponse.TrailerLoadCapacity  = trailer.TrailerLoadCapacity;


                trailerResponses.Add(trailerResponse);
            }

            return trailerResponses;
        }

        public async Task<string> Create(TrailerRequest request)
        {

            string error = string.Empty;
            if (string.IsNullOrEmpty(request.TrailerType))
            {
                return "Sorry tariler Type can not be null";
            }
                Trailers  trailerObj = new Trailers();


            trailerObj.TrailerWidth = request.TrailerWidth;
            trailerObj.TrailerVinNumber = request.TrailerVinNumber;
            trailerObj.TrailerLoadCapacity = request.TrailerLoadCapacity;
            trailerObj.TrailerType = request.TrailerType;
            // tractorsObj.id = request.ID;


            _dbContext.Trailers.Add(trailerObj);
            _dbContext.SaveChanges();

            error = "your data has been saved successfully!";

            return error;
        }


        public async Task<string> Update(TrailerRequest  request)
        {
            var trailer = _dbContext.Trailers.Where(x => x.Id == request.id).FirstOrDefault(); //

            if (trailer == null)
            {
                return "Sorry, the ID you provided does not exist!";
            }
            trailer.TrailerWidth = request.TrailerWidth;
            trailer.TrailerVinNumber = request.TrailerVinNumber;
            trailer.TrailerLoadCapacity = request.TrailerLoadCapacity;
            trailer.TrailerType = request.TrailerType;
            


            _dbContext.Trailers.Update(trailer);
            _dbContext.SaveChanges();

            return "your data has been updated successfully!";
        }

        public async Task<string> Delete(int id)
        {
            var data = _dbContext.Trailers.Where(x => x.Id == id).FirstOrDefault();

            if (data == null)
            {
                return "sorry, the Id you provided does not exist!";
            }

            _dbContext.Trailers.Remove(data);
            _dbContext.SaveChanges();

            return "your data has been deleted successfully!";
        }

    }
}
