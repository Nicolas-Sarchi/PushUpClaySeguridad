using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public string NombreCategoria { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}