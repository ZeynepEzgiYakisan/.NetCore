using MediatR;
using Onion.JwtApp.Aplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Aplication.Features.CQRS.Queries
{
    public class CheckUserQueryRequest: IRequest<CheckUserResponseDto>
    {
        public string UserName { get; set; } = null;
        public string Password { get; set; } = null;
    }
}
