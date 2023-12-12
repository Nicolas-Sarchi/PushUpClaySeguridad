using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, DataUserDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Contrato, ContratoDto>().ReverseMap();
            CreateMap<Contrato, ContratoActivoDto>().ForMember(d => d.NroContrato, o => o.MapFrom(c => c.Id))
            .ForMember(d => d.NombreCliente, o => o.MapFrom(c => c.Cliente.Nombre))
            .ForMember(d => d.NombreEmpleado, o => o.MapFrom(c => c.Empleado.Nombre))
            ;



            CreateMap<ContactoPersona, ContactoPersonaDto>().ReverseMap();
            CreateMap<ContactoPersona, ContactoPersonaDto>().ForMember(d => d.TipoContacto, o=> o.MapFrom(c => c.TipoContacto.Descripcion)
            ).ForMember(d => d.Persona, o => o.MapFrom(c => c.Persona.Nombre))
            .ForMember(d => d.Contacto, o => o.MapFrom(c => c.Descripcion));

            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<Direccion, DireccionDto>().ReverseMap();
            CreateMap<Direccion, DireccionDto>().ForMember(d => d.Ciudad, o=> o.MapFrom(d => d.Ciudad.NombreCiu))
            .ForMember(d => d.TipoDireccion, o => o.MapFrom(d => d.TipoDireccion.Descripcion))
            .ForMember(d => d.TipoVia, o => o.MapFrom(d => d.TipoVia.Descripcion));
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();

            CreateMap<Empleado, EmpleadoDto>().ForMember(e => e.Categoria, o => o.MapFrom(o=> o.Categoria.NombreCategoria ) );

            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<Programacion, ProgramacionDto>().ReverseMap();
            CreateMap<TipoContacto, TipoContactoDto>().ReverseMap();
            CreateMap<TipoDireccion, TipoDireccionDto>().ReverseMap();
            CreateMap<TipoVia, TipoViaDto>().ReverseMap();
            CreateMap<Turno, TurnoDto>().ReverseMap();
            

           

        }
    }
}