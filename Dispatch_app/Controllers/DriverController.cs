using Dispatch_app.Models;
using Dispatch_app.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dispatch_app.Controllers
{
    public class DriverController : Controller
    {
        IDriverRepo _IdriverRepo;

        public DriverController(IDriverRepo IdriverRepo)
        {
            _IdriverRepo = IdriverRepo;
        }
        ////CRUD



        [HttpGet]
       // [Route("GetDriver")]
        public DriverResponse GetDriver(int id)
        {

            var driverResponse = _IdriverRepo.GetDriver(id); 

            return driverResponse;
        }


        [HttpGet]
        //  [Route("GetDrivers")]
        public List<DriverResponse> GetDrivers()

        {
            var driverResponses = _IdriverRepo.GetDrivers();    

            return driverResponses;

        }


        [HttpPost]
        // [Route("Create")]
        public string Create([FromBody] DriverRequest request)
        {

            var response = _IdriverRepo.Create(request);
            return response;
        }

        [HttpPut]
        // [Route("Update")]
        public string Update([FromBody] DriverRequest request)
        {
            var response = _IdriverRepo.Update(request);
            return response;
        }


        [HttpDelete]
        [Route("Delete")]
        public string Delete(int id)
        {
            var response = _IdriverRepo.Delete(id);
            return response;
        }




}
}
