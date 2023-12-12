using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class EstadoRepository : GenericRepository<Estado> , IEstado
    {
     private readonly DBContext _context;
        public EstadoRepository(DBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Estado>> GetAllAsync()
{
 return await _context.Estados.ToListAsync();
}  
}
}