using Business.Case.Raizen.Api.Entities;
using Business.Case.Raizen.Api.Infra.Base;
using Business.Case.Raizen.Api.Infra.Context;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Business.Case.Raizen.APi.Infra.Repositories
{
    public class ClienteRepository : IRepository
    {
        public readonly dbBusinessCaseContext _context;

        public ClienteRepository(dbBusinessCaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            string sql = "Select * from Cliente order by nome desc";

            return await _context.Connection.QueryAsync<Cliente>(sql);
        }
        public async Task<int> Save(Cliente cliente)
        {
            try
            {
                return await _context.Connection.InsertAsync(cliente);
            }

            catch
            {
                throw new InvalidOperationException("Ocorreu um erro ao realizar essa operação");
            }
        }
        public async Task<Cliente> GetById(int id)
        {
            return await _context.Connection.GetAsync<Cliente>(id);
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _context.Connection.DeleteAsync(new Cliente { idCliente = id });
            }
            catch
            {
                throw new InvalidOperationException("Ocorreu um erro ao realizar essa operação");
            }
        }
        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            try
            {
                return await _context.Connection.UpdateAsync(cliente);
            }
            catch
            {

                throw new InvalidOperationException("Ocorreu um erro ao realizar essa operação");
            }
        }
        public async Task<int> CountClientes()
        {
            try
            {
                return await _context.Connection.ExecuteScalarAsync<int>("select count(*) from Clientes");
            }

            catch
            {
                throw new InvalidOperationException("Ocorreu um erro ao realizar essa operação");
            }
        }
    }
}
