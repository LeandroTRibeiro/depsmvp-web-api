using System.Net;
using DepsMvp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace depsmvp_web_api.Controllers;

[ApiController]
[Route("api/v1/company")]
public class CompanyController : ControllerBase
{
    public readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("cnpj/{cnpj}")]
    public async Task<IActionResult> GetCompanyByCnpj(string cnpj)
    {
        var response = await _companyService.GetCompany(cnpj);

        if (response.HttpCode == HttpStatusCode.OK)
        {
            return Ok(response.ReturnData);
        }
        else
        {
            return StatusCode((int)response.HttpCode, response.ErrorResponse);
        }
    }
}