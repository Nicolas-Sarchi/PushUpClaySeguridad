using Domain.Entities;
namespace Domain.Interfaces;

public interface ICliente : IGenericRepository<Cliente>
{
        public   Task<IEnumerable<Cliente>> GetBucaramanga();
        public   Task<IEnumerable<Cliente>> GetMas5anhos();


}