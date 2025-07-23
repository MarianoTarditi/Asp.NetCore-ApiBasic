using AutoMapper;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.MapperApp.ClientMapper
{
    public class ClientMapper : Profile
    {
        public ClientMapper()
        {
            CreateMap<ClientCreateDto, Client>().ReverseMap();
            CreateMap<ClientDto, Client>().ReverseMap();
            CreateMap<ClientDtoForInvoice, Client>().ReverseMap();
            CreateMap<ClientUpdateDto, Client>().ReverseMap();

        }
    }
}
