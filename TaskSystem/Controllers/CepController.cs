using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Integration.Interfaces;
using TaskSystem.Integration.Response;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;
        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration; 
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> findAdressData(string cep)
        {
            var responseData = await _viaCepIntegration.getDataViaCep(cep);

            if(responseData == null)
            {
                return BadRequest("Cep not found.");
            }

            return Ok(responseData);
        }
    }
}
