using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Services.InvoiceServices
{
    public interface IInvoiceService
    {
        #region BaseMethods
        Task<CustomResponseDto<List<InvoiceDto>>> GetAllInvoiceList();
        Task<CustomResponseDto<InvoiceDto>> GetInvoiceById(int id);
        Task<CustomResponseDto<InvoiceCreateDto>> CreateInvoice(InvoiceCreateDto request);
        Task<CustomResponseDto<NoContentDto>> UpdateInvoice(InvoiceUpdateForRemoveItemsDto request);
        Task<CustomResponseDto<NoContentDto>> DeleteInvoice(int id);
        #endregion

        #region InvoiceItemMethods
        Task<CustomResponseDto<NoContentDto>> RemoveInvoiceItems(RemoveInvoiceItemsDto request);
        Task<CustomResponseDto<List<InvoiceItemCreateDto>>> AddInvoiceItems(AddInvoiceItemsDto request);
        #endregion
    }
}
