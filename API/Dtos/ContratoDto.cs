using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ContratoDto : BaseDto
    {
        public int IdCliente { get; set; }
        public ClienteDto Cliente { get; set; }
        public DateOnly FechaContrato {get;set;}
        public DateOnly FechaFin {get;set;}
        public int IdEmpleado { get; set; }
        public EmpleadoDto Empleado { get; set; }           
        public int IdEstado { get; set; }
        public EstadoDto Estado { get; set; }
    }
}