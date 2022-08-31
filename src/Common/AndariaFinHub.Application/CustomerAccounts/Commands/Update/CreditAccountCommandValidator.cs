using AndariaFinHub.Application.Common.Exceptions;
using AndariaFinHub.Application.Common.Interfaces;
using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Application.Dto;
using AndariaFinHub.Domain.Entities;
using FluentValidation;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.CustomerAccounts.Commands.Update
{
    public class CreditAccountCommandValidator : AbstractValidator<CreditAccountCommand>
    {
        public CreditAccountCommandValidator()
        {
            RuleFor(v => v.Amount)
                 .GreaterThan(0).WithMessage("Amount must be greater than 0");

            RuleFor(v => v.CustomerId).NotNull().WithMessage("CustomerId must not be null");
        }
    }
}
