using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class DepartamentoRepository : GenericRepository<Departamento> , IDepartamento
    {
     private readonly DBContext _context;
        public DepartamentoRepository(DBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Departamento>> GetAllAsync()
{
 return await _context.Departamentos.ToListAsync();
}  
}
}