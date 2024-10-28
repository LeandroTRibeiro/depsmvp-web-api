using DepsMvp.Application.DTOs;

namespace depsmvp.application.Interfaces.Services;

public interface IPepsServices
{
    Task<ResponseGeneric<List<PepsResponse>>> GetPepsByCpfAsync(
            string cpf, 
            string referenceDate, 
            int interval
        );

    Task<ResponseGeneric<List<PepsResponse>>> GetPepsByConsultationtIdAsync(int consultationId);

}