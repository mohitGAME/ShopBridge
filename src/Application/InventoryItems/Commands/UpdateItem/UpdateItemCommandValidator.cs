using FluentValidation;

namespace ShopBridge.Application.InventoryItems.Commands.UpdateItem;
public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
{
    public UpdateItemCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
        RuleFor(v => v.Description)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Name)
           .NotEmpty();
        RuleFor(v => v.Price)
           .GreaterThan(0);
    }
}
