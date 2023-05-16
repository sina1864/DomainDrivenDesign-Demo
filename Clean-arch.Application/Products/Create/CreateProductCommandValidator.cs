using FluentValidation;

namespace Clean_arch.Application.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("توضیحات را وارد کنید")
            .MinimumLength(10).WithMessage("توضیحات باید بیشتر از 10 کاراکتر باشد");

        RuleFor(r => r.Price)
            .GreaterThanOrEqualTo(0).WithMessage("مبلغ وارد شده نامعتبر است");
    }
}