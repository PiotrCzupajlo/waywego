using Microsoft.AspNetCore.Mvc;
using waywegoapi.Models;

namespace waywegoapi.Controllers
{
    [ApiController]
    [Route("api/PinsRequestsController")]
    public class PinsDataRequestsController:ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Pin>> GetPins()
        {
            Pin pin = new Pin();
            return Ok(new List<Pin> { pin });
        }
    }
}
