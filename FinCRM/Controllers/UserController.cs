using FinCRM.Application.Services;
using FinCRM.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
           private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }
    

       
        
        [HttpGet]
        
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }


        [HttpGet("{id}")]
      
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            var createdUser = await _userService.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(int id, User user)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, user);

            if (updatedUser == null)
                return NotFound();

            return Ok(updatedUser);
        }



        //soft deklete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _userService.DeactivateUserAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
