using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators{
  
    public class UserValidator : AbstractValidator<User>{
       
        public UserValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Entity is required");
    
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                
                .NotNull()
                .WithMessage("Name is required")

                .MinimumLength(3)
                .WithMessage("Name must have at least 3 characters")

                .MaximumLength(50)
                .WithMessage("Name must have at most 50 characters");


            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")

                .NotNull()
                .WithMessage("Email is required")

                .MaximumLength(50)
                .WithMessage("Email must have at most 50 characters")

                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
                .WithMessage("Email is not valid");

            
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")

                .NotNull()
                .WithMessage("Password is required")

                .MinimumLength(6)   
                .WithMessage("Password must have at least 6 characters")

                .MaximumLength(30)
                .WithMessage("Password must have at most 30 characters");
        }
    }
}