using MediatR;
using ShopBridge.Application.Common.Exceptions;
using ShopBridge.Application.Common.Interfaces;
using ShopBridge.Domain.Entities;

namespace ShopBridge.Application.InventoryItems.Commands.DeleteItem;
public record DeleteItemCommand(int Id) : IRequest<Unit>;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand,Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Items
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Item), request.Id);
        }

        _context.Items.Remove(entity);

        //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
