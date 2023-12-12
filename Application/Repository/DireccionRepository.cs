using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class DireccionRepository : GenericRepository<Direccion> , IDireccion
    {
     private readonly DBContext _context;
        public DireccionRepository(DBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Direccion>> GetAllAsync()
{
 return await _context.Direccions.
 Include(d => d.Ciudad).
 Include(d => d.TipoDireccion).
 Include(d => d.TipoVia).ToListAsync();
}  
}
}