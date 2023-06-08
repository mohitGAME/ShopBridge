using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ShopBridge.Application.Common.Interfaces;
using ShopBridge.Application.Common.Mappings;
using ShopBridge.Application.Common.Models;

namespace ShopBridge.Application.InventoryItems.Queries.GetItemsWithPagination;
public record GetItemsWithPaginationQuery : IRequest<PaginatedList<ItemDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetItemsWithPaginationQueryHandler : IRequestHandler<GetItemsWithPaginationQuery, PaginatedList<ItemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ItemDto>> Handle(GetItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Items
            .OrderBy(x => x.Name)
            .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
