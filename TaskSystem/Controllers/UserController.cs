using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;
using TaskSystem.Services.User;

namespace TaskSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> findAll()
        {
            List<UserModel> user = await _service.GetAll();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> findById(int id)
        {
            UserModel user = await _service.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> createUser([FromBody] UserModel userModel)
        {
            UserModel user = await _service.Create(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UserModel>>> updateUser([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _service.Update(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserModel>>> deleteUser(int id)
        {
            bool deleted = await _service.Delete(id);
            return Ok(deleted);
        }
    }
}
