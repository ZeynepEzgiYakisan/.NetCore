﻿using MediatR;
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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await this.repository.GetByIdAsync(request.Id);

            if(updatedEntity != null)
            {
                updatedEntity.Name = request.Name;
                updatedEntity.Price = request.Price;
                updatedEntity.Stock = request.Stock;
                updatedEntity.CategoryId = request.CategoryId;
                await this.repository.UpdateAsync(updatedEntity);
            }
            return Unit.Value;
        }
    }
}
