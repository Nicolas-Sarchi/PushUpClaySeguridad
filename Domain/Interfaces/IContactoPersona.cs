using Domain.Entities;
namespace Domain.Interfaces;

public interface IContactoPersona : IGenericRepository<ContactoPersona>
{
        public Task<IEnumerable<ContactoPersona>> GetContactosVigilantes();

}