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
        public IActionResult GetByLazy()
        {
            var director = _directorService.GetAllByLazy();
            return Ok(director);
        }

        [HttpGet("Eager")]
        public IActionResult GetByEager()
        {
            var director = _directorService.GetAllByEager();
            return Ok(director);
        }
    }
}
