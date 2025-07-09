using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Services.ClientServices
{
    public interface IClientService
    {
        Task<CustomResponseDto<ClientCreateDto>> CreateClient(ClientCreateDto request);
        Task<CustomResponseDto<NoContentDto>> DeleteClient(int id);
        Task<CustomResponseDto<List<ClientDto>>> GetAllClientList();
        Task<CustomResponseDto<ClientDto>> GetClientById(int id);
        Task<CustomResponseDto<NoContentDto>> UpdateClient(ClientUpdateDto request);
    }

}
