﻿using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Checked { get; set; }
    }

    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Items.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Item), request.Id);
            }

            entity.Name = request.Name;
            entity.Checked = request.Checked;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
