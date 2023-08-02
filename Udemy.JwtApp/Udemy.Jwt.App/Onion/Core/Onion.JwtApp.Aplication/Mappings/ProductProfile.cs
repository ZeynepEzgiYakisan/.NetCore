using AutoMapper;
using Onion.JwtApp.Aplication.Dto;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Aplication.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            this.CreateMap<Product,ProductListDto>().ReverseMap();
            this.CreateMap<Product,CreatedCategoryDto>().ReverseMap();
        } 
    }
}
