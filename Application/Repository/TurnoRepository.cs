using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TurnoRepository : GenericRepository<Turno> , ITurno
    {
     private readonly DBContext _context;
        public TurnoRepository(DBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Turno>> GetAllAsync()
{
 return await _context.Turnos.ToListAsync();
}  
}
}