using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Lazy_Eager.Services;

namespace POC_Lazy_Eager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }



        [HttpGet("Lazy")]
        public IActionResult GetByLazy() //show the list of Directors with there Books By using lazy loading
        {
            var director = _directorService.GetAllByLazy(); 
            return Ok(director);
        }

        [HttpGet("Eager")]
        public IActionResult GetByEager() //show the list of Directors with there Books By using eager loading
        {
            var director = _directorService.GetAllByEager();
            return Ok(director);
        }
    }
}
