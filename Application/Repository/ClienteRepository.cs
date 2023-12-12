using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
        private readonly DBContext _context;
        public ClienteRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public  async Task<IEnumerable<Cliente>> GetBucaramanga()
        {
            return await _context.Clientes.
            Include(c => c.Direccion).
            ThenInclude(d => d.Ciudad).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoDireccion).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoVia).
            Where(c => c.Direccion.IdCiudad == 1).
            ToListAsync();
        }

        public  async Task<IEnumerable<Cliente>> GetMas5anhos()
        {
            return await _context.Clientes.
            Include(c => c.Direccion).
            ThenInclude(d => d.Ciudad).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoDireccion).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoVia).
            Where(c => c.FechaReg <= DateOnly.FromDateTime(DateTime.Now).AddYears(-5) ).
            ToListAsync();
        }
    }
}