using Microsoft.EntityFrameworkCore;
using ShopBridge.Domain.Entities;

namespace ShopBridge.Application.Common.Interfaces;
public interface IApplicationDbContext
{

    DbSet<Item> Items { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
