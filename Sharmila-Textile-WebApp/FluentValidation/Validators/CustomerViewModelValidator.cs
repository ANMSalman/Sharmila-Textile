using FluentValidation;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.FluentValidation.Validators {
    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel> {

        public CustomerViewModelValidator() {

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer Name cannot be empty")
                .MaximumLength(50).WithMessage("Maximum Characters allowed is 50");

            RuleFor(x => x.NIC)
                .NotEmpty().WithMessage("NIC cannot be empty")
                .Length(10, 12).WithMessage("NIC should have 10 - 12 characters");

            RuleFor(x => x.HomeLandline)
                .Matches(@"^\d{10}$")
                .When(x => x.HomeLandline != "")
                .WithMessage("Home Landline Number should have exactly 10 numbers");

            RuleFor(x => x.OfficeLandline)
                .Matches(@"^\d{10}$")
                .When(x => x.OfficeLandline != "")
                .WithMessage("Office Landline Number should have exactly 10 numbers");

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
