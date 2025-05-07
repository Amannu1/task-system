using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> findAll()
        {
            List<UserModel> user = await _userRepository.findAllUsers();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> findById(int id)
        {
            UserModel user = await _userRepository.findById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> createUser([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.createUser(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UserModel>>> updateUser([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.updateUser(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserModel>>> deleteUser(int id)
        {
            bool deleted = await _userRepository.deleteUser(id);
            return Ok(deleted);
        }
    }
}
