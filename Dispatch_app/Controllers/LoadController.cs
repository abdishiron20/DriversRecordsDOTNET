using Dispatch_app.Models;
using Dispatch_app.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Dispatch_app.Controllers
{
    public class LoadController : Controller
    {


        ILoadRepo _ILoadRepo;

        public LoadController(ILoadRepo ILoadRepo)
        {
            _ILoadRepo = ILoadRepo;
        }


        [HttpGet]

        public async Task<IActionResult> GetLoad(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loadResponse = await _ILoadRepo.GetLoad(id);

            return Ok(loadResponse);
        }


        [HttpGet]

        public List<LoadResponse> GetLoads()

        {
            var loadResponses = _ILoadRepo.GetLoads();

            return loadResponses;

        }


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] LoadRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _ILoadRepo.Create(request);
            return Ok(response);
        }

        [HttpPut]
        // [Route("Update")]
        public async Task<IActionResult> Update([FromBody] LoadRequest request)
        {
            var response = _ILoadRepo.Update(request);
            return Ok(response);
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = _ILoadRepo.Delete(id);
            return Ok(response);
        }

        public async Task<IActionResult> LoadAssignment(int driverId, int coDriverId, int loadId, int tractorId)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _ILoadRepo.LoadAssignment(driverId, coDriverId, loadId, tractorId);
             
            return Ok(response);



        }


    }

}
