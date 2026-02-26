using FinCRM.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static private List<User> users = new List<User>  // so this is like making fake data first ( and once - thats why its static)
        {
            new User
            {
                Id = 1,
                FirstName = "Richard",
                LastName = "Smith",
                Email = "catchmeifyoucan@gmail.com",
                //allow me to do this fopr now i guess 
                PasswordHash = "123",
                RoleId = 1,
                IsActive = true,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow,

            },

              new User
            {
                Id = 2,
                FirstName = "Victory",
                LastName = "Smither",
                Email = "catchmeifyoucant@gmail.com",
                PasswordHash = "1234",
                RoleId = 2,
                IsActive = true,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow,

            },
              new User
              {
                  Id = 3,
                  FirstName = "Elena",
                  LastName = "Martinez",
                  Email = "elena.martinez@fincrm.com",
                  PasswordHash = "5678",
                  RoleId = 2,
                  IsActive = false,
                  CreatedAt = DateTimeOffset.UtcNow,
                  UpdatedAt = DateTimeOffset.UtcNow,
              }

        };  // probably our userRepo dependency will be injected here
       
        
        [HttpGet]
        public ActionResult<List<User>> GetUsers() //  this method signature will remain the same even if we have a database record , cause we want to release a List of Users
        {
            return Ok(users);
        }


        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

    }
}
