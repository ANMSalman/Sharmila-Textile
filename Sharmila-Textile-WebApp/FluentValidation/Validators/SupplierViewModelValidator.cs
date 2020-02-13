using FluentValidation;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.FluentValidation.Validators {
    public class SupplierViewModelValidator : AbstractValidator<SupplierViewModel> {

        public SupplierViewModelValidator() {
            RuleFor(x => x.SupplierName)
                .NotEmpty().WithMessage("Supplier Name cannot be empty")
                .MaximumLength(50).WithMessage("Maximum Characters allowed is 50");

            RuleFor(x => x.Landline)
                .Matches(@"^\d{10}$")
                .When(x => x.Landline!="")
                .WithMessage("Landline Number should have exactly 10 numbers");

            RuleFor(x => x.Mobile)
                .Matches(@"^\d{10}$")
                .When(x => x.Mobile != "")
                .WithMessage("Mobile Number should have exactly 10 numbers");

            RuleFor(x => x.OpeningBalance)
                .NotEmpty().WithMessage("Opening Balance cannot be empty")
                .ScalePrecision(2, 18).WithMessage("Number should be within 2 decimal place");

            RuleFor(x => x.CurrentBalance)
                .NotEmpty().WithMessage("Current Balance cannot be empty")
                .ScalePrecision(2, 18).WithMessage("Number should be within 2 decimal place");

        }

    }
}
