using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = DAL.DO.Objects;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<data.Empleado, DataModels.Empleado>().ReverseMap();
            CreateMap<data.Cliente, DataModels.Cliente>().ReverseMap();
            CreateMap<data.Producto, DataModels.Producto>().ReverseMap();
            CreateMap<data.Proveedores, DataModels.Proveedores>().ReverseMap();
            CreateMap<data.Puesto, DataModels.Puesto>().ReverseMap();
        }
    }
}
