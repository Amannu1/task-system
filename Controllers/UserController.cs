using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Controllers
{
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
    }
}
