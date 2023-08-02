using MediatR;

namespace UdemyJwtApp.Back.Core.Application.Features.CQRS.Command
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }

        public string? Definition { get; set; }
    }
}
