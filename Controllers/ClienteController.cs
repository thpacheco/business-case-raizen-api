using Business.Case.Raizen.Api.Application;
using Business.Case.Raizen.Api.Application.Dtos;
using Business.Case.Raizen.Api.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace Business.Case.Raizen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(ResponseBase.CreateSuccess(await _clienteService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(ResponseBase.CreateSuccess(await _clienteService.GetByIdAsyncs(id)));
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] ClienteDto cliente)
        {
            try
            {

                var result = await _clienteService.InsertClienteAsync(cliente);
                if (result > 0) return Ok(ResponseBase.CreateSuccess("Cliente cadastrado com sucesso!"));

                return BadRequest(ResponseBase.CreateError("Erro o criar novo cliente."));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseBase.CreateError(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmailClienteAsync(int id, [FromBody] ClienteDto clienteDto)
        {
            try
            {
                var result = await _clienteService.UpdateClienteAsync(id, clienteDto);
                if (result) return Ok(ResponseBase.CreateSuccess("Update efetuado com sucesso!"));

                return BadRequest(ResponseBase.CreateError("Erro o criar novo cliente."));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseBase.CreateError(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _clienteService.DeleteClienteAsync(id);
                if (result) return Ok(ResponseBase.CreateSuccess("Registro excluído com sucesso!"));

                return BadRequest(ResponseBase.CreateError("Erro ao excluindo cliente."));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseBase.CreateError(ex.Message));
            }
        }
    }
}
