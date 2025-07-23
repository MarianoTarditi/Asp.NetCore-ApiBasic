using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using YouTube.AspNetCore.API.Tutorial.Basic.Exceptions;
using YouTube.AspNetCore.API.Tutorial.Basic.GenericRepositories;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Entities;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Services.ClientServices
{
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<Client> _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IGenericRepository<Client> clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<ClientCreateDto>> CreateClient(ClientCreateDto request)
        {
            var client = _mapper.Map<Client>(request);
            await _clientRepository.Create(client);
            return CustomResponseDto<ClientCreateDto>.Success(request, 201);
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteClient(int id)
        {
            var client =  await _clientRepository.GetEntityById(id);
            if (client is null)
            {
                throw new ClientSideException("Client not exist");
            }
            await _clientRepository.Delete(client);
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<List<ClientDto>>> GetAllClientList()
        {
            var clients = await _clientRepository.GetAllList().ToListAsync();
            var mappedList = _mapper.Map<List<ClientDto>>(clients);
            return CustomResponseDto<List<ClientDto>>.Success(mappedList, 200);
        }

        public async Task<CustomResponseDto<ClientDto>> GetClientById(int id)
        {
            var client = await _clientRepository.GetAllList()
                                                .Include(x => x.Invoices)
                                                .FirstOrDefaultAsync(x => x.Id == id);

            if (client is null)
                throw new ClientSideException("Client not exist");

            var mappedItem = _mapper.Map<ClientDto>(client); // ✅ Mapeo correcto

            return CustomResponseDto<ClientDto>.Success(mappedItem, 200);
        }


        public async Task<CustomResponseDto<NoContentDto>> UpdateClient(ClientUpdateDto request)
        {
            var client = _clientRepository.GetAllList().FirstOrDefault(x => x.Id == request.Id);

            if (client is null)
                throw new ClientSideException("Client not exist");

            var mappedItem = _mapper.Map(request, client);
            await _clientRepository.Update(mappedItem);
            return CustomResponseDto<NoContentDto>.Success(204);
        }
    }
}
