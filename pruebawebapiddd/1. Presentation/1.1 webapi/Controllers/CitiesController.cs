using Application.Contracts;
 using Microsoft.AspNetCore.Mvc;

 namespace pruebaapiddd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _ICitiesService;

        public CitiesController(ICitiesService _ICitiesService)
        {
            this._ICitiesService = _ICitiesService;
            
        }

        [HttpGet]
        [Route("GetCities")]
        public IActionResult GetCities()
        {
            var Response = _ICitiesService.GetCities();
            return Ok(Response);
        }
    }
}