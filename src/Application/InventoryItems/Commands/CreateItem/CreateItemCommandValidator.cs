using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Application.Common.Interfaces;

namespace ShopBridge.Application.InventoryItems.Commands.CreateItem;
public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateItemCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(v => v.Description)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Name)
           .NotEmpty().
           Must(IsUniqueItem).WithMessage("{PropertyName} already exists."); ;
        RuleFor(v => v.Price)
           .GreaterThan(0);
    }
    private bool IsUniqueItem(string name)
    {
        return _context.Items.FirstOrDefault(u => u.Name == name) == null;
    }
}
