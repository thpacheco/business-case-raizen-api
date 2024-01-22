using AutoMapper;
using Business.Case.Raizen.Api.Application.Dtos;
using Business.Case.Raizen.Api.Entities;
using System;

namespace Business.Case.Raizen.Api.Infra.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>()
                .ForMember(cliente => cliente.idCliente, opt => opt.Ignore());
        }
    }
}
