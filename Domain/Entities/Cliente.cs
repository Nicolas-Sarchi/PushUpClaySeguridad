using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string IdPersona { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaReg { get; set; }
        public int IdDireccion { get; set; }
        public Direccion Direccion { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        public ICollection<ContactoPersona> ContactoPersonas { get; set; }
    }
}