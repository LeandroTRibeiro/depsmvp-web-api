using System.ComponentModel.DataAnnotations;
using System.Net;
using DepsMvp.Application.DTOs;
using depsmvp.application.Interfaces.Services;
using depsmvp.application.Requests;
using depsmvp.application.Validators;
using Microsoft.AspNetCore.Mvc;

namespace depsmvp_web_api.Controllers;

[ApiController]
[Route("api/v1/peps")]
public class PepsController : ControllerBase
{
    public readonly IPepsServices PepsServices;

    public PepsController(IPepsServices pepsServices)
    {
        PepsServices = pepsServices;
    }

    [HttpPost("cpf/")]
    [ProducesResponseType(typeof(List<PepsResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPepsByCpfAsync(
        [FromBody] [Required] GetPepsByCpfRequest request
    )
    {
        if (!request.Cpf.IsValidCpf())
        {
            return BadRequest(new { message = "Invalid CPF." });
        }

        if (!DateTime.TryParseExact(request.ReferenceDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,
                out DateTime parsedDate))
        {
            return BadRequest(new { message = "Invalid reference date format. Expected format is dd/MM/yyyy." });
        }

        try
        {
            var response = await PepsServices.GetPepsByCpfAsync(request.Cpf, request.ReferenceDate, request.Interval);

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

    [HttpGet("pep/")]
    [ProducesResponseType(typeof(List<PepsResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPepsByConsultationtIdAsync([FromQuery] [Required] int id)
    {
        try
        {
            var response = await PepsServices.GetPepsByConsultationtIdAsync(id);

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