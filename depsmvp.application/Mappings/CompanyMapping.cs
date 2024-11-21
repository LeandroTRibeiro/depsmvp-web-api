using AutoMapper;
using DepsMvp.Application.DTOs;
using depsmvp.domain.Entities.Company;

namespace depsmvp.application.Mappings;

public class CompanyMapping : Profile
{
    public CompanyMapping()
    {
        CreateMap(typeof(ResponseGeneric<>), typeof(ResponseGeneric<>));
        CreateMap<CompanyResponse, Company>();
        CreateMap<Company, CompanyResponse>();

        CreateMap<CnaesSecundario, CnaesSecundarioResponse>();
        CreateMap<CnaesSecundarioResponse, CnaesSecundario>();

        CreateMap<Qsa, QsaResponse>();
        CreateMap<QsaResponse, Qsa>();
    }
}