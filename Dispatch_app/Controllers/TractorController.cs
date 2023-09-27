using Dispatch_app.Models;
using Dispatch_app.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dispatch_app.Controllers
{
    public class TractorController : Controller
    {
        //public DriverController(IDriverRepo IdriverRepo)
        //{
        //    _IdriverRepo = IdriverRepo;
        //}


        ITractorRepo _ItractorRepo;

        public TractorController(ITractorRepo ItractorRepo)
        {
            _ItractorRepo = ItractorRepo;
        }


        [HttpGet]
        // [Route("GetDriver")]
        public async Task<IActionResult> GetTractor(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tractorResponse = await _ItractorRepo.GetTractor(id);

            return Ok(tractorResponse);
        }


        [HttpGet]
        //  [Route("GetDrivers")]
        public List<TractorResponse> GetTractors()

        {
            var tractorResponses = _ItractorRepo.GetTractors();

            return tractorResponses;

        }


        [HttpPost]
        // [Route("Create")]
        public async Task<IActionResult> Create([FromBody] TractorRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _ItractorRepo.Create(request);
            return Ok(response);
        }

        [HttpPut]
        // [Route("Update")]
        public async Task<IActionResult> Update([FromBody] TractorRequest request)
        {
            var response = _ItractorRepo.Update(request);
            return Ok(response);
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = _ItractorRepo.Delete(id);
            return Ok(response);
        }
    }

    }
