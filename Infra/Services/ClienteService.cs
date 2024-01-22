using AutoMapper;
using Business.Case.Raizen.Api.Application.Dtos;
using Business.Case.Raizen.Api.Domain.Interfaces;
using Business.Case.Raizen.Api.Entities;
using Business.Case.Raizen.APi.Infra.Repositories;


namespace Business.Case.Raizen.Api.Infra.Services
{
    public class ClienteService : IService
    {
        private readonly ClienteRepository _ClienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(ClienteRepository ClienteRepository, IMapper mapper)
        {
            _ClienteRepository = ClienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync() => await _ClienteRepository.GetAll();
        public async Task<Cliente> GetByIdAsyncs(int id) => await _ClienteRepository.GetById(id);
        public async Task<int> InsertClienteAsync(ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);

            return await _ClienteRepository.Save(cliente);
        }
        public async Task<bool> UpdateClienteAsync(int id, ClienteDto clienteDto)
        {
            var clienteUpdate = await _ClienteRepository.GetById(id);

            clienteUpdate.nome = clienteDto.Nome;
            clienteUpdate.email = clienteDto.Email;
            clienteUpdate.dataNascimento = clienteDto.DataNascimento;
            clienteUpdate.cep = clienteDto.Cep;

            var cliente = _mapper.Map<Cliente>(clienteUpdate);

            return await _ClienteRepository.UpdateClienteAsync(cliente);
        }
        public async Task<bool> DeleteClienteAsync(int id)
        {

            return await _ClienteRepository.Delete(id);
        }
    }
}
