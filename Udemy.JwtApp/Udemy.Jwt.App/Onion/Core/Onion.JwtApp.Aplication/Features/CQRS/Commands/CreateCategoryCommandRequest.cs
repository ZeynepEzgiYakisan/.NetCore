using MediatR;
using Onion.JwtApp.Aplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApp.Aplication.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest<CreatedCategoryDto?>
    {
        public string? Definition { get; set; }
    }
}
