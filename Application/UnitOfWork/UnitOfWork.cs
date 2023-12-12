using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContext context;
        private RoleRepository _Roles;
        private UserRepository _Users;
        private CategoriaRepository _Categorias;
        private CiudadRepository _Ciudads;
        private ClienteRepository _Clientes;
        private ContactoPersonaRepository _ContactoPersonas;
        private ContratoRepository _Contratos;
        private DepartamentoRepository _Departamentos;
        private DireccionRepository _Direcciones;
        private EmpleadoRepository _Empleados;
        private EstadoRepository _Estados;
        private PaisRepository _Paises;
        private ProgramacionRepository _Programaciones;
        private TipoContactoRepository _TiposContacto;
        private TipoDireccionRepository _TiposDireccion;
        private TipoViaRepository _TiposVia;
        private TurnoRepository _Turnos;

    



        public UnitOfWork(DBContext _context)
        {
            context = _context;
        }


        public IRole Roles
        {
            get
            {
                if (_Roles == null)
                {
                    _Roles = new RoleRepository(context);
                }
                return _Roles;
            }
        }

        public IUser Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(context);
                }
                return _Users;
            }
        }
        public ICategoria Categorias
        {
            get
            {
                if (_Categorias == null)
                {
                    _Categorias = new CategoriaRepository(context);
                }
                return _Categorias;
            }
        }
        public ICiudad Ciudads
        {
            get
            {
                if (_Ciudads == null)
                {
                    _Ciudads = new CiudadRepository(context);
                }
                return _Ciudads;
            }
        }
        public ICliente Clientes
        {
            get
            {
                if (_Clientes == null)
                {
                    _Clientes = new ClienteRepository(context);
                }
                return _Clientes;
            }
        }
        public IContactoPersona ContactoPersonas
        {
            get
            {
                if (_ContactoPersonas == null)
                {
                    _ContactoPersonas = new ContactoPersonaRepository(context);
                }
                return _ContactoPersonas;
            }
        }
        public IContrato Contratos
        {
            get
            {
                if (_Contratos == null)
                {
                    _Contratos = new ContratoRepository(context);
                }
                return _Contratos;
            }
        }
        public IDepartamento Departamentos
        {
            get
            {
                if (_Departamentos == null)
                {
                    _Departamentos = new DepartamentoRepository(context);
                }
                return _Departamentos;
            }
        }
        public IDireccion Direccions
        {
            get
            {
                if (_Direcciones == null)
                {
                    _Direcciones = new DireccionRepository(context);
                }
                return _Direcciones;
            }
        }
        public IEmpleado Empleados
        {
            get
            {
                if (_Empleados == null)
                {
                    _Empleados = new EmpleadoRepository(context);
                }
                return _Empleados;
            }
        }
        public IEstado Estados
        {
            get
            {
                if (_Estados == null)
                {
                    _Estados = new EstadoRepository(context);
                }
                return _Estados;
            }
        }
        public IPais Paises
        {
            get
            {
                if (_Paises == null)
                {
                    _Paises = new PaisRepository(context);
                }
                return _Paises;
            }
        }
        public IProgramacion Programaciones
        {
            get
            {
                if (_Programaciones == null)
                {
                    _Programaciones = new ProgramacionRepository(context);
                }
                return _Programaciones;
            }
        }
        public ITipoContacto TiposContacto
        {
            get
            {
                if (_TiposContacto == null)
                {
                    _TiposContacto = new TipoContactoRepository(context);
                }
                return _TiposContacto;
            }
        }
        public ITipoDireccion TiposDireccion
        {
            get
            {
                if (_TiposDireccion == null)
                {
                    _TiposDireccion = new TipoDireccionRepository(context);
                }
                return _TiposDireccion;
            }
        }
        public ITipoVia TiposVia
        {
            get
            {
                if (_TiposVia == null)
                {
                    _TiposVia = new TipoViaRepository(context);
                }
                return _TiposVia;
            }
        }
        public ITurno Turnos
        {
            get
            {
                if (_Turnos == null)
                {
                    _Turnos = new TurnoRepository(context);
                }
                return _Turnos;
            }
        }
      
        public int Save()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
        }

    }
}