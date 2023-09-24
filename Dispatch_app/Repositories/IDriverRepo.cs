using Dispatch_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dispatch_app.Repositories
{
    public interface IDriverRepo
    {
        public DriverResponse GetDriver(int id);
        public List<DriverResponse> GetDrivers();
        public string Create(DriverRequest request);

        public string Update(DriverRequest request );  //this should be coming as DriverRequest ? But why <?>

        public string Delete(int id);
    }
}
