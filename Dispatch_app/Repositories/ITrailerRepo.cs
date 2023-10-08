using Dispatch_app.Models;

namespace Dispatch_app.Repositories
{
    public interface ITrailerRepo
    {
        public Task<TrailerResponse> GetTrailer(int id);
        public List<TrailerResponse> GetTrailers();
        public Task<string> Create(TrailerRequest request);

        public Task<string> Update(TrailerRequest request);

        public Task<string> Delete(int id);
    }
}
