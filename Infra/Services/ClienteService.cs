using AutoMapper;
using Business.Case.Raizen.Api.Application.Dtos;
using Business.Case.Raizen.Api.Domain.Interfaces;
using Business.Case.Raizen.Api.Entities;
using Business.Case.Raizen.APi.Infra.Repositories;
using static Dapper.SqlMapper;
using Newtonsoft.Json;


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
        public async Task<Cliente> GetByIdAsync(int id) => await _ClienteRepository.GetById(id);
        public async Task<ClienteCepDto> GetCepAsync(string cep)
        {
            string apiUrl = $"https://viacep.com.br/ws/{cep}/json/";
            var clienteCep = new ClienteCepDto();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Fazer a chamada GET para o endpoint
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    // Verificar se a chamada foi bem-sucedida (código 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Ler e imprimir os dados da resposta
                        string contentStream = await response.Content.ReadAsStringAsync();
                        clienteCep = JsonConvert.DeserializeObject<ClienteCepDto>(contentStream);

                        return clienteCep;
                    }
                    else
                    {
                        // Tratar o erro, se necessário
                        Console.WriteLine($"Erro: {response.StatusCode} - {response.ReasonPhrase}");
                        return new ClienteCepDto();
                    }
                }
                catch (Exception ex)
                {
                    // Lidar com exceções, se ocorrerem
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }

            return clienteCep;
        }

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
