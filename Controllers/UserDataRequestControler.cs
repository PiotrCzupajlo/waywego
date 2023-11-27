using Microsoft.AspNetCore.Mvc;
using waywegoapi.Models;

namespace waywegoapi.Controllers
{
    [Route("api/UserDataRequest")]
    [ApiController]
    public class UserDataRequestControler : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> GetUsers() { 
        User user = new User();
        User user1 = new User();
        
            return new List<User> { user, user1 };

        }






    }
}
