using Microsoft.AspNetCore.Mvc;
using YouTube.AspNetCore.API.Tutorial.Basic.Exceptions;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto;
using YouTube.AspNetCore.API.Tutorial.Basic.Services.ClientServices;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : CustomBaseController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // baseaddress/api/client
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _clientService.GetAllClientList();
            return CreateAction(result);
        }

        // baseaddress/api/client/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var result = await _clientService.GetClientById(id);
            return CreateAction(result);
        }

        // baseaddress/api/client
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientCreateDto request)
        {
            var result = await _clientService.CreateClient(request);
            return CreateAction(result);
        }

        // baseaddress/api/client
        [HttpPut]
        public async Task<IActionResult> UpdateClient(ClientUpdateDto request)
        {
            var result = await _clientService.UpdateClient(request);
            return CreateAction(result);
        }

        // baseaddress/api/client/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var result = await _clientService.DeleteClient(id);
            return CreateAction(result);
        }
    }
}
