using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get() => Ok(new List<object> 
        { 
            new { Name = "Demo User", Role = "Admin" } 
        });
    }
}
