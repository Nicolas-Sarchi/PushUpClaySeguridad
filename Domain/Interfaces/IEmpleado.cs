using Domain.Entities;
namespace Domain.Interfaces;

public interface IEmpleado : IGenericRepository<Empleado>
{
        public  Task<IEnumerable<Empleado>> GetVigilantes();
        public   Task<IEnumerable<Empleado>> GetGironPiedecuesta();


}