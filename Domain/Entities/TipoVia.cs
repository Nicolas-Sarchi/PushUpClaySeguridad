using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoVia : BaseEntity
    {
        public string Descripcion { get; set; }
        public ICollection<Direccion> Direcciones { get; set; }
    }
}