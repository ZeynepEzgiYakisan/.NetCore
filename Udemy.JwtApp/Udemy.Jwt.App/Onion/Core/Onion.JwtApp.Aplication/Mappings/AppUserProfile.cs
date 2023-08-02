﻿using AutoMapper;
using Onion.JwtApp.Aplication.Dto;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Aplication.Mappings
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile() 
        { 
            this.CreateMap<AppUser, CreatedUserDto>().ReverseMap();
        }
    }
}
