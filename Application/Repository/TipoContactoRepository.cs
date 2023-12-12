using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoContactoRepository : GenericRepository<TipoContacto> , ITipoContacto
    {
     private readonly DBContext _context;
        public TipoContactoRepository(DBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<TipoContacto>> GetAllAsync()
{
 return await _context.TiposContacto.ToListAsync();
}  
}
}