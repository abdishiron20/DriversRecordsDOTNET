using Dispatch_app.Models;
using Dispatch_app.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dispatch_app.Controllers
{
    public class TrailerController : Controller
    {
        //public DriverController(IDriverRepo IdriverRepo)
        //{
        //    _IdriverRepo = IdriverRepo;
        //}



        ITrailerRepo _TrailerRepo;


        public TrailerController(ITrailerRepo ITrailerRepo)
        {
            _TrailerRepo = ITrailerRepo;
        }


        [HttpGet]
        // [Route("GetDriver")]
        public async Task<IActionResult> GetTrailer(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trailerResponse = await _TrailerRepo.GetTrailer(id);

            return Ok(trailerResponse);
        }


        [HttpGet]
  
        public List<TrailerResponse> GetTrailers()

        {
            var trailerResponses = _TrailerRepo.GetTrailers();

            return trailerResponses;

        }


        [HttpPost]
       
        public async Task<IActionResult> Create([FromBody] TrailerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _TrailerRepo.Create(request);
            return Ok(response);
        }

        [HttpPut]
        // [Route("Update")]
        public async Task<IActionResult> Update([FromBody] TrailerRequest request)
        {
            var response = _TrailerRepo.Update(request);
            return Ok(response);
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = _TrailerRepo.Delete(id);
            return Ok(response);
        }
    }

}
