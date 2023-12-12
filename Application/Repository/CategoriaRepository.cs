using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria> , ICategoria
    {
     private readonly DBContext _context;
        public CategoriaRepository(DBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Categoria>> GetAllAsync()
{
 return await _context.Categorias.ToListAsync();
}  
}
}