using Microsoft.AspNetCore.Mvc;
using waywegoapi.Models;

namespace waywegoapi.Controllers
{
    [ApiController]
    [Route("api/PlacesDataRequest")]
    public class PlacesDataRequestController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<Place> GetPlaces()
        {
            Place place = new Place();
            return new List<Place> { place };

        }
    }
}
