using System.ComponentModel.DataAnnotations;
using System.Net;
using DepsMvp.Application.DTOs;
using DepsMvp.Application.Services;
using depsmvp.application.Validators;
using depsmvp.domain.Entities;
using depsmvp.insfrastructure.InternalServices;
using Microsoft.AspNetCore.Mvc;

namespace depsmvp_web_api.Controllers;

[ApiController]
[Route("api/v1/company")]
public class CompanyController : ControllerBase
{
    public readonly ICompanyServices CompanyServices;

    public CompanyController(ICompanyServices companyServices)
    {
        CompanyServices = companyServices;
    }

    [HttpGet("cnpj/")]
    [ProducesResponseType(typeof(CompanyResponse), (int)HttpStatusCode.OK)]              
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]         
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Unauthorized)]       
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Forbidden)]          
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.NotFound)]           
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCompanyByCnpj(
        [FromQuery][Required]string cnpj
        )
    {
        if (!CNPJValidator.IsValidCnpj(cnpj))
        {
            return BadRequest(new { message = "Invalid CNPJ" });
        }

        try
        {
            var response = await CompanyServices.GetCompany(cnpj);

            if (response.HttpCode == HttpStatusCode.OK)
            {
                return Ok(response.ReturnData);
            }
            else
            {
                return StatusCode((int)response.HttpCode, response.ErrorResponse);
            }

        }
        catch (Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, 
                new
                {
                    message = "An error occurred while processing your request.",
                    details = exception.Message
                });
        }
    }
    
}