using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ProgramacionRepository : GenericRepository<Programacion> , IProgramacion
    {
     private readonly DBContext _context;
        public ProgramacionRepository(DBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Programacion>> GetAllAsync()
{
 return await _context.Programaciones.ToListAsync();
}  
}
}