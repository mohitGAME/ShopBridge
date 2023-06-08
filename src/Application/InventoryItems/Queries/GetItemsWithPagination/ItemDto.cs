using ShopBridge.Application.Common.Mappings;
using ShopBridge.Domain.Entities;

namespace ShopBridge.Application.InventoryItems.Queries.GetItemsWithPagination;
public class ItemDto : IMapFrom<Item>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
}
