using MediatR;
using ShopBridge.Application.Common.Interfaces;
using ShopBridge.Domain.Entities;

namespace ShopBridge.Application.InventoryItems.Commands.CreateItem;
public record CreateItemCommand : IRequest<int>
{

    public required string Name { get; init; }
    public required string Description { get; init; }
    public double Price { get; init; }
}

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new Item
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
        };

        //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.Items.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
