using TaskSystem.Integration.Interfaces;
using TaskSystem.Integration.Refit;
using TaskSystem.Integration.Response;

namespace TaskSystem.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }
        public async Task<ViaCepResponse> getDataViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.getDataViaCep(cep);
            
            if(responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            return null;
        }
    }
}
