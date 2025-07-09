using Microsoft.EntityFrameworkCore;
using YouTube.AspNetCore.API.Tutorial.Basic.Exceptions;
using YouTube.AspNetCore.API.Tutorial.Basic.GenericRepositories;
using YouTube.AspNetCore.API.Tutorial.Basic.MapperApp;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoiceItemsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.InvoicesDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Services.InvoiceServices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IGenericRepository<Invoice> _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IGenericRepository<Invoice> invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        #region BaseMethods

        public async Task<CustomResponseDto<InvoiceCreateDto>> CreateInvoice(InvoiceCreateDto request)
        {
            var invoice = _mapper.Map<InvoiceCreateDto, Invoice>(request, 3);
            await _invoiceRepository.Create(invoice);
            return CustomResponseDto<InvoiceCreateDto>.Success(request, 201);
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteInvoice(int id)
        {
            var invoice = await _invoiceRepository.GetEntityById(id);
            if (invoice is null)
                throw new ClientSideException("Invoice not exist");

            await _invoiceRepository.Delete(invoice);
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<List<InvoiceDto>>> GetAllInvoiceList()
        {
            var invoices = await _invoiceRepository.GetAllList().Include(x => x.InvoiceItems).Include(x => x.Client).ToListAsync();


            var mappedList = _mapper.Map<List<Invoice>, List<InvoiceDto>>(invoices, 3);
            return CustomResponseDto<List<InvoiceDto>>.Success(mappedList, 200);
        }

        public async Task<CustomResponseDto<InvoiceDto>> GetInvoiceById(int id)
        {
            var invoices = await _invoiceRepository.GetAllList().Include(x => x.InvoiceItems).Include(x => x.Client).ToListAsync();
            var invoice = invoices.FirstOrDefault(x => x.Id == id);

            if (invoice is null)
                throw new ClientSideException("Invoice not exist");

            var mappedItem = _mapper.Map<Invoice, InvoiceDto>(invoice, 3);
            return CustomResponseDto<InvoiceDto>.Success(mappedItem, 200);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateInvoice(InvoiceUpdateForRemoveItemsDto request)
        {
            var invoice = _invoiceRepository.GetAllList().Include(x => x.InvoiceItems).FirstOrDefault(x => x.Id == request.Id);

            if (invoice is null)
                throw new ClientSideException("Invoice not exist");

            var mappedItem = _mapper.Map(request, invoice, 3);
            await  _invoiceRepository.Update(mappedItem);
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        #endregion

        #region InvoiceItemMethods

        public async Task<CustomResponseDto<NoContentDto>> RemoveInvoiceItems(RemoveInvoiceItemsDto request)
        {
            var invoice = await _invoiceRepository //tracked
                           .GetAllList()
                           .Include(x => x.InvoiceItems)
                           .FirstOrDefaultAsync(x => x.Id == request.InvoiceId); 

            if (invoice is null)
                throw new ClientSideException("Invoice not exist");

            var invoiceDto = _mapper.Map<Invoice, InvoiceUpdateForRemoveItemsDto>(invoice, 3);

            List<string> errorMessages = new();
            foreach (var removeItemId in request.RemoveInvoiceItemIdList)
            {
                var removeItem = invoiceDto.InvoiceItems.FirstOrDefault(x => x.Id == removeItemId);
                if (removeItem is null)
                {
                    errorMessages.Add($"Item no:{removeItemId} not exist");
                    continue;
                }
                invoiceDto.InvoiceItems.Remove(removeItem);
            }

            if (errorMessages.Any())
                return CustomResponseDto<NoContentDto>.Fail(400, errorMessages);

            var updatedInvoice = _mapper.Map(invoiceDto, invoice, 3);

            if (!updatedInvoice.InvoiceItems.Any())
                await _invoiceRepository.Delete(updatedInvoice);
            else
                await _invoiceRepository.Update(updatedInvoice);

            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<List<InvoiceItemCreateDto>>> AddInvoiceItems(AddInvoiceItemsDto request)
        {
            var invoice = await _invoiceRepository //tracked
               .GetAllList()
               .Include(x => x.InvoiceItems)
               .FirstOrDefaultAsync(x => x.Id == request.InvoiceId);

            if (invoice is null)
                throw new ClientSideException("Invoice not exist");

            var invoiceDto = _mapper.Map<Invoice, InvoiceUpdateForAddItemsDto>(invoice, 3);
            invoiceDto.InvoiceItems!.AddRange(request.InvoiceItemList);

            var updatedInvoice = _mapper.Map(invoiceDto, invoice, 3);
            await _invoiceRepository.Update(updatedInvoice);

            return CustomResponseDto<List<InvoiceItemCreateDto>>.Success(request.InvoiceItemList, 201);
        }

        #endregion
    }
}
