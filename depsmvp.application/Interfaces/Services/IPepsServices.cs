using DepsMvp.Application.DTOs;

namespace depsmvp.application.Interfaces.Services;

public interface IPepsServices
{
    Task<ResponseGeneric<List<PepsResponse>>> GetPeps(
            string cpf, 
            string referenceDate, 
            int interval
        );
}