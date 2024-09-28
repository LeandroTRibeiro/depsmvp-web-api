using System.Dynamic;
using System.Text.Json;
using DepsMvp.Application.DTOs;
using DepsMvp.Application.Services;
using depsmvp.domain.Entities.Company;

namespace depsmvp.insfrastructure.ExternalServices;

public class BrasilApi : IBrasilApi
{
    public async Task<ResponseGeneric<Company>> GetCompany(string cnpj)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cnpj/v1/{cnpj}");
        
        var response = new ResponseGeneric<Company>();
        
        using (var client = new HttpClient())
        {
            var responseBrasilApi = await client.SendAsync(request);
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
                response.ErrorResponse = JsonSerializer.Deserialize<ExpandoObject>(contetResponse);
            }
        }

        Console.WriteLine("estou fazendo uma requisicao");
        return response;
    }
}