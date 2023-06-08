using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Domain.Entities;
public class Item : BaseAuditableEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public double Price { get; set; }
}
