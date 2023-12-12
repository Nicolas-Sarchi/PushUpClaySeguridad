using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoDto  : BaseDto
    {
        public string IdPersona { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaReg { get; set; }
        public DireccionDto Direccion { get; set; }
        public string Categoria { get; set; }
    }
}