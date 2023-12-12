using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ContactoPersonaRepository : GenericRepository<ContactoPersona>, IContactoPersona
    {
        private readonly DBContext _context;
        public ContactoPersonaRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ContactoPersona>> GetAllAsync()
        {
            return await _context.ContactoPersonas.ToListAsync();
        }

        public  async Task<IEnumerable<ContactoPersona>> GetContactosVigilantes()
        {
            return await _context.ContactoPersonas.Where(c => c.Persona.IdCategoria == 1)
            .Include(c => c.Persona)
            .Include(c => c.TipoContacto)
            .ToListAsync();
        }
    }
}