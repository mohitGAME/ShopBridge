using MediatR;
using ShopBridge.Application.Common.Exceptions;
using ShopBridge.Application.Common.Interfaces;
using ShopBridge.Domain.Entities;
    
namespace ShopBridge.Application.InventoryItems.Commands.UpdateItem;
public record UpdateItemCommand : IRequest<Unit>
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public double Price { get; init; }
}

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Items
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Item), request.Id);
        }
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Price = request.Price;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
