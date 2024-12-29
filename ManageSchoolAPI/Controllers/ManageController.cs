using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync()
        {
            return Ok();
        }
    }
}
