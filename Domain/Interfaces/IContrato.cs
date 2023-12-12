using Domain.Entities;
namespace Domain.Interfaces;

public interface IContrato : IGenericRepository<Contrato>
{
        public   Task<IEnumerable<Contrato>> GetActivos();

}