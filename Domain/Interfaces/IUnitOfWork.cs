using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRole Roles { get; }
        IUser Users { get; }
        ICategoria Categorias { get; }
        ICiudad Ciudads { get; }
        ICliente Clientes { get; }
        IContactoPersona ContactoPersonas { get; }
        IContrato Contratos { get; }
        IDepartamento Departamentos { get; }
        IDireccion Direccions { get; }
        IEmpleado Empleados { get; }
        IEstado Estados { get; }
        IPais Paises { get; }
        IProgramacion Programaciones { get; }
        ITipoContacto TiposContacto { get; }
        ITipoDireccion TiposDireccion { get; }
        ITipoVia TiposVia { get; }

        ITurno Turnos { get; }
        

        Task<int> SaveAsync();
    }
}