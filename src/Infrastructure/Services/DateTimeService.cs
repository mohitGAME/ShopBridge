using ShopBridge.Application.Common.Interfaces;

namespace ShopBridge.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
