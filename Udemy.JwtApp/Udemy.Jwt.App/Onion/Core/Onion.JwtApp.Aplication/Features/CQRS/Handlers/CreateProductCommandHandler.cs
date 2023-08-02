using AutoMapper;
using MediatR;
using Onion.JwtApp.Aplication.Dto;
using Onion.JwtApp.Aplication.Features.CQRS.Commands;
using Onion.JwtApp.Aplication.Interfaces;
using Onion.JwtApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Aplication.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreatedProductDto?>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedProductDto?> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.CreateAsync(new Product
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });
            return this.mapper.Map<CreatedProductDto>(data);
        }
    }
}
