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
    public readonly ICompanyService _companyService;
    public readonly IConsultService _consultService;

    public CompanyController(ICompanyService companyService, IConsultService consultService)
    {
        _companyService = companyService;
        _consultService = consultService;
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
        if (!CnpjValidator.IsValidCnpj(cnpj))
        {
            return BadRequest(new { message = "Invalid CNPJ" });
        }

        try
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

    [HttpGet("consults/")]
    [ProducesResponseType(typeof(PagedResponse<List<Consult>>), (int)HttpStatusCode.OK)]              
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]       
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Unauthorized)]     
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Forbidden)]        
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.NotFound)]         
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.InternalServerError)] 
    public async Task<IActionResult> GetConsults(
        [FromQuery] int? limit = null, 
        [FromQuery][Required] int pageNumber = 1, 
        [FromQuery][Required] int pageSize = 10)
    {
        try
        {
            if (pageNumber < 1)
            {
                return BadRequest(new ErrorDetails
                {
                    Message = "Page number must be greater than or equal to 1."
                });
            }

            if (pageSize < 1)
            {
                return BadRequest(new ErrorDetails
                {
                    Message = "Page size must be greater than or equal to 1."
                });
            }
        
            var consults = await _consultService.GetAllConsultsAsync(limit, pageNumber, pageSize);

            return Ok(consults);
        }
        catch (Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, 
                new ErrorDetails 
                { 
                    Message = "An error occurred while processing your request.", 
                    Details = exception.Message 
                });
        }
    }
}