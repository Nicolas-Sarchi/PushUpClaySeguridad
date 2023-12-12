using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ContactoPersonaDto : BaseDto
    {
       public string Contacto { get; set; }
        public string Persona { get; set; }
        public string TipoContacto { get; set; }
    }


}