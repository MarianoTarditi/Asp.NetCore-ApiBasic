using AutoMapper;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.MapperApp.InvoiceMapper
{
    public class InvoiceMapper : Profile
    {
        public InvoiceMapper()
        {
            CreateMap<InvoiceCreateDto, Invoice>().ReverseMap();
            CreateMap<InvoiceDto, Invoice>().ReverseMap();
            CreateMap<InvoiceDtoForClient, Invoice>().ReverseMap();
            CreateMap<InvoiceUpdateForAddItemsDto, Invoice>().ReverseMap();
            CreateMap<InvoiceUpdateForRemoveItemsDto, Invoice>().ReverseMap();
        }
    }
}
