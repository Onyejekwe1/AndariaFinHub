﻿using AndariaFinHub.Application.Common.Exceptions;
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
    public class FxConversionCommandValidator : AbstractValidator<FxConversionCommand>
    {
        public FxConversionCommandValidator()
        {
            RuleFor(v => v.Amount)
                 .GreaterThan(0).WithMessage("Amount must be greater than 0");

            RuleFor(v => v.SourceCustomerAccountId).NotNull().WithMessage("Source Account Id must not be null");
            RuleFor(v => v.DestinationCustomerAccountId).NotNull().WithMessage("Destination Account Id must not be null");
        }
    }
}
