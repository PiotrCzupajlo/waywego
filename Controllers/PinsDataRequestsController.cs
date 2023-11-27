using Microsoft.AspNetCore.Mvc;
using waywegoapi.Models;

namespace waywegoapi.Controllers
{
    [ApiController]
    [Route("api/PinsRequestsController")]
    public class PinsDataRequestsController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<Pin> GetPins()
        {
            Pin pin = new Pin();
            return new List<Pin> { pin };
        }
    }
}
