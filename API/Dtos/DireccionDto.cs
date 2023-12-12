using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DireccionDto : BaseDto
    {
        public string NroPrincipal { get; set; }
        public string NroSecundario { get; set; }
        public string Complemento { get; set; }
        public string InfoAdicional { get; set; }
        public string TipoVia { get; set; }
        public string TipoDireccion { get; set; }
        public string Ciudad { get; set; }
    }
}