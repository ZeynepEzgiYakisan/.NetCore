using MediatR;

namespace UdemyJwtApp.Back.Core.Application.Features.CQRS.Command
{
    public class DeleteProductCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteProductCommandRequest(int id)
        {
            Id = id;
        }
    }
}
