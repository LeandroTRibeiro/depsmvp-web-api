using AutoMapper;
using DepsMvp.Application.DTOs;
using depsmvp.domain.Entities;

namespace depsmvp.application.Mappings;

public class PepsMapping : Profile
{
    public PepsMapping()
    {
        CreateMap(typeof(ResponseGeneric<>), typeof(ResponseGeneric<>));

        CreateMap<PepsResponse, Pep>();
        CreateMap<Pep, PepsResponse>();
    }
}