using AutoMapper;
using MediatR;
using Onion.JwtApp.Aplication.Dto;
using Onion.JwtApp.Aplication.Enums;
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
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, CreatedUserDto?>
    {
        private readonly IRepository<AppUser> repository;
        private readonly IMapper mapper;

        public RegisterUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedUserDto?> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.CreateAsync(new AppUser
            {
                AppRoleId = (int)RoleType.Member,
                Username = request.UserName,
                Password = request.Password,
            });

            return this.mapper.Map<CreatedUserDto>(data);
        }
    }
}
