﻿using MediatR;

namespace UdemyJwtApp.Back.Core.Application.Features.CQRS.Command
{
    public class DeleteCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteCategoryCommandRequest(int id) 
        {
            Id = id;
        }
    }
}