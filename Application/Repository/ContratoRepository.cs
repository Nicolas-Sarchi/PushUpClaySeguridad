using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ContratoRepository : GenericRepository<Contrato>, IContrato
    {
        private readonly DBContext _context;
        public ContratoRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Contrato>> GetAllAsync()
        {
            return await _context.Contratos.ToListAsync();
        }

        public  async Task<IEnumerable<Contrato>> GetActivos()
        {
            return await _context.Contratos
            .Include(c => c.Cliente)
            .Include(c => c.Empleado).
            Where(c => c.IdEstado == 1).ToListAsync();
        }
    }
}