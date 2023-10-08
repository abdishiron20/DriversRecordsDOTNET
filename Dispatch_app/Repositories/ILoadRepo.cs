using Dispatch_app.Models;
using NuGet.Protocol.Plugins;

namespace Dispatch_app.Repositories
{
    public interface ILoadRepo
    {
       
            public Task<LoadResponse> GetLoad(int id);
            public List<LoadResponse> GetLoads();
            public Task<string> Create(LoadRequest request);

            public Task<string> Update(LoadRequest request);  

            public Task<string> Delete(int id);

            public Task<string> LoadAssignment(int driverId, int coDriverId, int loadId, int tractorId);


    }
}
