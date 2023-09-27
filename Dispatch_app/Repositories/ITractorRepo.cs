using Dispatch_app.Models;

namespace Dispatch_app.Repositories
{
    public interface ITractorRepo
    {
        //changes must be made here 
        public Task<TractorResponse> GetTractor(int id);
        public List<TractorResponse> GetTractors();
        public Task<string> Create(TractorRequest request);

        public Task<string> Update(TractorRequest request);  

        public Task<string> Delete(int id);
    }
}
