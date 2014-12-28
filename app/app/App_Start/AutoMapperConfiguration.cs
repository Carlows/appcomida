using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using app.Models.Entities;
using app.Models.ViewModels;

namespace app.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            ConfigureMappings();
        }

        private static void ConfigureMappings()
        {
            Mapper.CreateMap<RegistroViewModel, Registro>().ReverseMap();
            Mapper.CreateMap<ProductoViewModel, Producto>().ReverseMap();
            Mapper.CreateMap<DireccionViewModel, Direccion>().ReverseMap();
        } 
    }
}