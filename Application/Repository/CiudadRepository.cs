using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class CiudadRepository : GenericRepository<Ciudad> , ICiudad
    {
     private readonly DBContext _context;
        public CiudadRepository(DBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Ciudad>> GetAllAsync()
{
 return await _context.Ciudades.ToListAsync();
}  
}
}