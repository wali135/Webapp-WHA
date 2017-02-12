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
            Mapper.CreateMap<Hydrants, HydrantDto>();
            Mapper.CreateMap<Entry, EntryDto>();



            Mapper.CreateMap<DriverDto, Drivers>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<HydrantDto, Hydrants>().ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}