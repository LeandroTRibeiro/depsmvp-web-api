using System.Text.Json;
using DepsMvp.Application.DTOs;
using depsmvp.application.Interfaces.Services;
using DepsMvp.Application.Services;
using depsmvp.domain.Entities;
using Microsoft.Extensions.Configuration;

namespace depsmvp.insfrastructure.ExternalServices;

public class PortalDaTrasparenciaApi : IPortalDaTrasparenciaApi
{
    private readonly HttpClient _httpClient;

    public PortalDaTrasparenciaApi(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseGeneric<List<Pep>>> GetPepAsync(string cpf, DateTime referenceDate, int interval)
    {
        var baseUrl = Environment.GetEnvironmentVariable("PORTAL_TRANSPARENCIA_BASE_URL");
        var endpoint = Environment.GetEnvironmentVariable("PORTAL_TRANSPARENCIA_ENDPOINT_PEPS");
        var apiKeyName = Environment.GetEnvironmentVariable("PORTAL_TRANSPARENCIA_API_KEY_NAME");
        var apiKeyValue = Environment.GetEnvironmentVariable("PORTAL_TRANSPARENCIA_API_KEY");
        
        if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(endpoint) || 
            string.IsNullOrEmpty(apiKeyName) || string.IsNullOrEmpty(apiKeyValue))
        {
            throw new Exception("Variáveis de ambiente do Portal da Transparência não estão configuradas corretamente.");
        }

        var startUntil = referenceDate.ToString("dd/MM/yyyy");
        var startFrom = referenceDate.AddDays(-interval).ToString("dd/MM/yyyy");

        var requestUrl =
            $"{baseUrl}{endpoint}{cpf}&dataInicioExercicioDe={startFrom}&dataInicioExercicioAte={startUntil}";
        
        var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
        request.Headers.Add(apiKeyName, apiKeyValue);

        var response = new ResponseGeneric<List<Pep>>();

        var responsePortalTransparencia = await _httpClient.SendAsync(request);

        var responseString = await responsePortalTransparencia.Content.ReadAsStringAsync();

        var objResponse = JsonSerializer.Deserialize<List<Pep>>(responseString);

        if (responsePortalTransparencia.IsSuccessStatusCode)
        {
            response.HttpCode = responsePortalTransparencia.StatusCode;
            response.ReturnData = objResponse;
        }
        else
        {
            response.HttpCode = responsePortalTransparencia.StatusCode;
            response.ErrorResponse = JsonSerializer.Deserialize<ErrorDetails>(responseString);
        }

        return response;
    }
}