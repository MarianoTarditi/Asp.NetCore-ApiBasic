using AutoMapper;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;

namespace YouTube.AspNetCore.API.Tutorial.Basic.MapperApp.InvoiceItemsMapper
{
    public class InvoiceItemsMapper : Profile
    {
        public InvoiceItemsMapper()
        {
            CreateMap<AddInvoiceItemsDto, InvoiceItem>().ReverseMap();
            CreateMap<InvoiceItemCreateDto, InvoiceItem>().ReverseMap();
            CreateMap<InvoiceItemDto, InvoiceItem>().ReverseMap();
            CreateMap<InvoiceItemUpdateDto, InvoiceItem>().ReverseMap();
            CreateMap<RemoveInvoiceItemsDto, InvoiceItem>().ReverseMap();

        }
    }
}
