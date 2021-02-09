using Application.Contracts;
 using Microsoft.AspNetCore.Mvc;

 namespace pruebaapiddd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsService _IDepartmentsService;

        public DepartmentsController(IDepartmentsService _IDepartmentsService)
        {
            this._IDepartmentsService = _IDepartmentsService;
            
        }

        [HttpGet]
        [Route("GetDepartments")]
        public IActionResult GetDepartments()
        {
            var Response = _IDepartmentsService.GetDepartments();
            return Ok(Response);
        }
    }
}