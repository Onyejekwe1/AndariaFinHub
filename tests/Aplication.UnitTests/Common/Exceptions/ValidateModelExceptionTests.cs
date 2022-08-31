﻿using System;
using AndariaFinHub.Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace AndariaFinHub.Application.UnitTests.Common.Exceptions
{
    public class ValidateModelExceptionTests
    {
        [Test]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidateModelException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

    }
}
