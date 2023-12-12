using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        private readonly DBContext _context;
        public EmpleadoRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Empleados.Include(e => e.Direccion).ThenInclude(d => d.Ciudad).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoDireccion).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoVia).Include(e => e.Categoria).ToListAsync();
        }

        public  async Task<IEnumerable<Empleado>> GetVigilantes()
        {
            return await _context.Empleados.Include(e => e.Direccion).ThenInclude(d => d.Ciudad).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoDireccion).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoVia)
            .Include(e => e.Categoria)
            .Where(e => e.IdCategoria == 1)
            .ToListAsync();
        }

        public  async Task<IEnumerable<Empleado>> GetGironPiedecuesta()
        {
            return await _context.Empleados.Include(e => e.Direccion).ThenInclude(d => d.Ciudad).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoDireccion).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoVia)
            .Include(e => e.Categoria)
            .Where(e => e.Direccion.IdCiudad == 2 || e.Direccion.IdCiudad == 3)
            .ToListAsync();
        }
    }
}