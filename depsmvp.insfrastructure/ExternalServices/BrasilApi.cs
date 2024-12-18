using System.Text.Json;
using DepsMvp.Application.DTOs;
using DepsMvp.Application.Services;
using depsmvp.domain.Entities.Company;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace depsmvp.insfrastructure.ExternalServices
{
    public class BrasilApi : IBrasilApi
    {
        private readonly HttpClient _httpClient;
        private readonly string _brasilApiUrl;

        public BrasilApi(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _brasilApiUrl = Environment.GetEnvironmentVariable("BRASIL_API_URL");
            
            if (string.IsNullOrEmpty(_brasilApiUrl))
            {
                throw new Exception("A variável de ambiente BRASIL_API_URL não está configurada.");
            }
        }

        public async Task<ResponseGeneric<Company>> GetCompanyAsync(string cnpj)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_brasilApiUrl}{cnpj}");

            request.Headers.Add("User-Agent", "MvpDeps/1.0");

            var response = new ResponseGeneric<Company>();

            var responseBrasilApi = await _httpClient.SendAsync(request);
            var contetResponse = await responseBrasilApi.Content.ReadAsStringAsync();

            var objResponse = JsonSerializer.Deserialize<Company>(contetResponse);

            if (responseBrasilApi.IsSuccessStatusCode)
            {
                response.HttpCode = responseBrasilApi.StatusCode;
                response.ReturnData = objResponse;
            }
            else
            {
                response.HttpCode = responseBrasilApi.StatusCode;
                response.ErrorResponse = JsonSerializer.Deserialize<ErrorDetails>(contetResponse);
            }

            return response;
        }
    }
}