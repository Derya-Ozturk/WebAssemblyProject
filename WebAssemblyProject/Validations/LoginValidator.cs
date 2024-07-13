using Entities.Dtos;
using FluentValidation;

namespace WebAssemblyProject.Validations
{
    public class LoginValidator : AbstractValidator<UserDto>
    {
        public LoginValidator()
        {
            RuleFor(login => login.Mail).NotEmpty().WithMessage("Mail address cannot be empty")
                                        .Length(3, 100).WithMessage("Mail address length can be at least 1 and up to 100")
                                        .WithName("Mail");

            RuleFor(login => login.Password)
                                            .NotEmpty().WithMessage("Password cannot be empty")
                                            .Length(3, 20).WithMessage("Password length can be at least 1 and up to 20")
                                            .WithName("Password");
        }
    }
}
