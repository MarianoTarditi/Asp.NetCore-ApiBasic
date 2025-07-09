using Microsoft.AspNetCore.Mvc;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Services.InvoiceServices;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : CustomBaseController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // baseaddress/api/Invoice/GetallInvoices
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var result = await _invoiceService.GetAllInvoiceList();
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/GetInvoiceById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var result = await _invoiceService.GetInvoiceById(id);
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/CreateInvoice
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(InvoiceCreateDto request)
        {
            var result = await _invoiceService.CreateInvoice(request);
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/UpdateInvoice
        [HttpPut]
        public async Task<IActionResult> UpdateInvoice(InvoiceUpdateForRemoveItemsDto request)
        {
            var result = await _invoiceService.UpdateInvoice(request);
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/DeleteInvoice
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _invoiceService.DeleteInvoice(id);
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/RemoveInvoiceItems
        [HttpPut()]
        public async Task<IActionResult> RemoveInvoiceItems(RemoveInvoiceItemsDto request)
        {
            var result = await _invoiceService.RemoveInvoiceItems(request);
            return CreateAction(result);
        }

        // baseaddress/api/Invoice/AddInvoiceItems
        [HttpPut()]
        public async Task<IActionResult> AddInvoiceItems(AddInvoiceItemsDto request)
        {
            var result = await _invoiceService.AddInvoiceItems(request);
            return CreateAction(result);
        }
    }
}