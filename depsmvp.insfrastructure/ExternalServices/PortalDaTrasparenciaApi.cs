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
    private readonly IConfiguration _configuration;

    public PortalDaTrasparenciaApi(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<ResponseGeneric<List<Pep>>> GetPepAsync(string cpf, DateTime referenceDate, int interval)
    {
        var baseUrl = _configuration["ExternalServices:PortalDaTrasparenciaApi:BaseUrl"];
        var endpoint = _configuration["ExternalServices:PortalDaTrasparenciaApi:EndPoints:Peps"];
        var apiKeyName = _configuration["ExternalServices:PortalDaTrasparenciaApi:Header:Authorization:Name"];
        var apiKeyValue = _configuration["ExternalServices:PortalDaTrasparenciaApi:Header:Authorization:Value"];

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