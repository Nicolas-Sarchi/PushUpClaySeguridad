# PushUpClaySeguridad

## Consultas


> Listar Todos los empleados de la empresa de seguridad
  - URL : ```http://localhost:5193/api/Empleado ```
    ```c#
    public override async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Empleados.Include(e => e.Direccion).ThenInclude(d => d.Ciudad).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoDireccion).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoVia).Include(e => e.Categoria).ToListAsync();
        }
    ```
    


> Listar Todos los empleados que son vigilantes
  - URL : ```http://localhost:5193/api/Empleado/vigilantes ```
     ```c#
    public  async Task<IEnumerable<Empleado>> GetVigilantes()
        {
            return await _context.Empleados.Include(e => e.Direccion).ThenInclude(d => d.Ciudad).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoDireccion).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoVia)
            .Include(e => e.Categoria)
            .Where(e => e.IdCategoria == 1)
            .ToListAsync();
        }
    ```
    
    

> Listar los números de contacto de un empleado que sea vigilante
  - URL : ```http://localhost:5193/api/contactopersona/vigilantes ```
     ```c#
    public  async Task<IEnumerable<ContactoPersona>> GetContactosVigilantes()
        {
            return await _context.ContactoPersonas.Where(c => c.Persona.IdCategoria == 1)
            .Include(c => c.Persona)
            .Include(c => c.TipoContacto)
            .ToListAsync();
        }
    ```
> Listar todos los clientes que vivan el la ciudad de bucaramanga
  - URL : ```http://localhost:5193/api/cliente/bucaramanga ```
     ```c#
    public  async Task<IEnumerable<Cliente>> GetBucaramanga()
        {
            return await _context.Clientes.
            Include(c => c.Direccion).
            ThenInclude(d => d.Ciudad).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoDireccion).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoVia).
            Where(c => c.Direccion.IdCiudad == 1).
            ToListAsync();
        }
    ```
> Listar todos los empleados que vivan el la Girón y en piedecuesta
  - URL : ```http://localhost:5193/api/empleado/GironyPiedecuesta```
     ```c#
    public  async Task<IEnumerable<Empleado>> GetGironPiedecuesta()
        {
            return await _context.Empleados.Include(e => e.Direccion).ThenInclude(d => d.Ciudad).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoDireccion).
            Include(e => e.Direccion).
            ThenInclude(d => d.TipoVia)
            .Include(e => e.Categoria)
            .Where(e => e.Direccion.IdCiudad == 2 || e.Direccion.IdCiudad == 3)
            .ToListAsync();
        
        }
    ```

> Listar todos los clientes que tengan más de 5 años de antiguedad
  - URL : ```http://localhost:5193/api/cliente/Mas5Ahos```
     ```c#
     public  async Task<IEnumerable<Cliente>> GetMas5anhos()
          {
              return await _context.Clientes.
              Include(c => c.Direccion).
              ThenInclude(d => d.Ciudad).
              Include(e => e.Direccion).
              ThenInclude(d => d.TipoDireccion).
              Include(e => e.Direccion).
              ThenInclude(d => d.TipoVia).
              Where(c => c.FechaReg <= DateOnly.FromDateTime(DateTime.Now).AddYears(-5) ).
              ToListAsync();
          }
    ```

> Listar todos los contratos cuyo estado es activo. Se debe mostrar el Nro de contrato, el nombre del cliente y el empleado que registró el contrato
  - URL : ```http://localhost:5193/api/contrato/activos```
     ```c#
    public  async Task<IEnumerable<Contrato>> GetActivos()
        {
            return await _context.Contratos
            .Include(c => c.Cliente)
            .Include(c => c.Empleado).
            Where(c => c.IdEstado == 1).ToListAsync();
        }
    ```    
    
    

    
    

