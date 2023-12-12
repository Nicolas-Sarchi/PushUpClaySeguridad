using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoViaRepository : GenericRepository<TipoVia> , ITipoVia
    {
     private readonly DBContext _context;
        public TipoViaRepository(DBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<TipoVia>> GetAllAsync()
{
 return await _context.TiposVia.ToListAsync();
}  
}
}