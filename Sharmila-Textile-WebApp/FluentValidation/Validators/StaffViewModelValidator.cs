using FluentValidation;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.FluentValidation.Validators {
    public class StaffViewModelValidator : AbstractValidator<StaffViewModel> {

        public StaffViewModelValidator() {
            RuleFor(x =>x.StaffName)
                .NotEmpty().WithMessage("Staff Name cannot be empty")
                .MaximumLength(50).WithMessage("Maximum Characters allowed is 50");

            RuleFor(x => x.Nic)
                .NotEmpty().WithMessage("NIC cannot be empty")
                .Length(10, 12).WithMessage("NIC should have 10 - 12 characters");

            RuleFor(x => x.ContactNo)
                .Matches(@"^\d{10}$")
                .When(x => x.ContactNo != "")
                .WithMessage("Contact Number should have exactly 10 characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address cannot be empty");

            RuleFor(x => x.UserViewModel.UserName)
                .Empty().Unless(x => x.UserViewModel.UserName.Length == 10).WithMessage("Username should have exactly 10 characters")
                .OverridePropertyName("UserName");

            RuleFor(x => x.UserViewModel.Password)
                .Empty().Unless(x => x.UserViewModel.Password.Length >= 8).WithMessage("Password should have more than 8 characters") 
                .OverridePropertyName("Password");

            RuleFor(x => x.UserViewModel.Password)
                .Empty().Unless(x => x.UserViewModel.Password.Length <= 50).WithMessage("Maximum Characters allowed is 50") 
                .OverridePropertyName("Password");

        }
    }
}
