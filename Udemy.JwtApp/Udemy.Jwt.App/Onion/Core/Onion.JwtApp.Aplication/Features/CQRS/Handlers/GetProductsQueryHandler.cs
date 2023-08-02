﻿using AutoMapper;
using MediatR;
using Onion.JwtApp.Aplication.Dto;
using Onion.JwtApp.Aplication.Features.CQRS.Queries;
using Onion.JwtApp.Aplication.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Aplication.Features.CQRS.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public GetProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await this.repository.GetAllAsync();

            return this.mapper.Map<List<ProductListDto>>(products);
        }
    }
}
