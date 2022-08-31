using AndariaFinHub.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.Customers.Commands.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateCustomerCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(v => v.FirstName)
                .MaximumLength(20).WithMessage("First Name must not exceed 20 characters.")
                .NotEmpty().WithMessage("First Name is required");
            RuleFor(v => v.LastName)
                .MaximumLength(20).WithMessage("Last Name must not exceed 20 characters.")
                .NotEmpty().WithMessage("Last Name is required.");
            RuleFor(m => m.IdNumber)
                .MaximumLength(8).WithMessage("Maltese ID number cannot exceed 8 characters")
                .Matches(@"^[0-9a-zA-Z ]+$")
                .WithMessage("Numbers and letters only please.");
            RuleFor(d => d.DateOfBirth)
                .Must(IsAValidAge)
                .WithMessage("User must be at least 18 years old.");
            RuleFor(c => c.EmailAddress)
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Wrong Email format");
            RuleFor(v => v.Username)
                .MaximumLength(30).WithMessage("Username must not exceed 30 characters");
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("Minimum length is 8 characters")
                .MaximumLength(50).WithMessage("Maximum length is 50 characters")
                .Matches("[A-Z]").WithMessage("Password must contain upper case letter")
                .Matches("[a-z]").WithMessage("Password must contain lower case letter")
                .Matches("[0-9]").WithMessage("Password must contain a digit")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain special character");

        }

        protected bool IsAValidAge(DateTime date)   
        {
        
            if (date < DateTime.Now.AddYears(-18))
            {
                return true;
            }

            return false;
        }

        private async Task<bool> UniqueId(string IdNumber, CancellationToken cancellationToken)
        {
            //TODO: Handle case sensitivity and cultureInfo
            return await _dbContext.Customers.AllAsync(x => x.IdNumber != IdNumber, cancellationToken);
        }
    }
}
