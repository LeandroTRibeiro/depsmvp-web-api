using System.ComponentModel.DataAnnotations;
using System.Net;
using DepsMvp.Application.DTOs;
using depsmvp.application.Requests;
using DepsMvp.Application.Services;
using depsmvp.application.Validators;
using depsmvp.domain.Entities;
using depsmvp.insfrastructure.InternalServices;
using Microsoft.AspNetCore.Mvc;

namespace depsmvp_web_api.Controllers;

[ApiController]
[Route("api/v1/companies")]
public class CompanyController : ControllerBase
{
    public readonly ICompanyServices CompanyServices;

    public CompanyController(ICompanyServices companyServices)
    {
        CompanyServices = companyServices;
    }

    [HttpPost("cnpj/")]
    [ProducesResponseType(typeof(CompanyResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCompanyByCnpjAsync(
        [FromBody] [Required] GetCompanyByCnpjRequest request
    )
    {
        if (!request.Cnpj.IsValidCnpj())
        {
            return BadRequest(new { message = "Invalid CNPJ" });
        }

        if (!DateTime.TryParseExact(request.ReferenceDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,
                out DateTime parsedDate))
        {
            return BadRequest(new { message = "Invalid reference date format. Expected format is dd/MM/yyyy." });
        }

        try
        {
            var response = await CompanyServices.GetCompanyAsync(request.Cnpj, request.ReferenceDate, request.Interval);

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


    [HttpGet("company/")]
    [ProducesResponseType(typeof(CompanyResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails),
        (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorDetails),
        (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCompanyByConsultationIdAsync(
        [FromQuery] [Required] int consultationId)
    {
        try
        {
            var response = await CompanyServices.GetCompanyByConsultationtIdAsync(consultationId);

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