using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Direccion : BaseEntity
    {
        public string NroPrincipal { get; set; }
        public string NroSecundario { get; set; }
        public string Complemento { get; set; }
        public string InfoAdicional { get; set; }
        public int IdTipoVia { get; set; }
        public TipoVia TipoVia { get; set; }
        public int IdTipoDireccion { get; set; }
        public TipoDireccion TipoDireccion { get; set; }
        public int IdCiudad { get; set; }
        public Ciudad Ciudad { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Empleado> Empleados { get; set; }

    }
}