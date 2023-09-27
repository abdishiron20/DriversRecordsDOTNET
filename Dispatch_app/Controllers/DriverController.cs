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
        public async Task<IActionResult> GetDriver(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driverResponse =  await _IdriverRepo.GetDriver(id); 

            return Ok(driverResponse);
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
        public async Task<IActionResult> Create([FromBody] DriverRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = _IdriverRepo.Create(request);
            return Ok(response);
        }

        [HttpPut]
        // [Route("Update")]
        public async Task<IActionResult> Update([FromBody] DriverRequest request)
        {
            var response = _IdriverRepo.Update(request);
            return Ok(response);
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = _IdriverRepo.Delete(id);
            return Ok(response);
        }




}
}
