using Dispatch_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dispatch_app.Repositories
{
    public interface IDriverRepo
    {
        public Task<DriverResponse> GetDriver(int id);
        public List<DriverResponse> GetDrivers();
        public Task<string> Create(DriverRequest request);

        public Task<string> Update(DriverRequest request );  //this should be coming as DriverRequest ? But why <?>

        public Task<string> Delete(int id);
    }
}
