using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using AutoMapper;
using WHA.Dtos;
using WHA.Models;

namespace WHA.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Drivers, DriverDto>();
            Mapper.CreateMap<DriverDto, Drivers>();
        }
    }
}