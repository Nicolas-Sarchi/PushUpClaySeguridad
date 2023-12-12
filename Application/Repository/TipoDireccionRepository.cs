using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoDireccionRepository : GenericRepository<TipoDireccion> , ITipoDireccion
    {
     private readonly DBContext _context;
        public TipoDireccionRepository(DBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<TipoDireccion>> GetAllAsync()
{
 return await _context.TiposDireccion.ToListAsync();
}  
}
}