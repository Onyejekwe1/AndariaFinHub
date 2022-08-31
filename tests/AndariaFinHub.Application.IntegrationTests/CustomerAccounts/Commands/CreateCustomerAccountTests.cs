using System;
using System.Threading.Tasks;
using AndariaFinHub.Application.Common.Exceptions;
using AndariaFinHub.Application.CustomerAccounts.Commands.Create;
using AndariaFinHub.Application.Customers.Commands.Create;
using AndariaFinHub.Domain.Entities;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using static AndariaFinHub.Application.IntegrationTests.Testing;

namespace AndariaFinHub.Application.IntegrationTests.Districts.Commands
{
    public class CreateCustomerAccountTests 
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateCustomerAccountCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();

        }

        [Test]
        public async Task ShouldCreateDistrict()
        {
            var city = await SendAsync(new CreateCustomerCommand
            {
                FirstName = "Test Name",
                LastName = "Last Name",
                DateOfBirth = DateTime.Now.AddYears(-22),
                EmailAddress = "ifeanyi_test@yahoo.com",
                Username = "testUser",
                Password = "Laporta1.!",
                IdNumber = "M7386274"
            });

            var userId = await RunAsDefaultUserAsync();

            var command = new CreateCustomerAccountCommand
            {
                CustomerId = city.Data.Id,
                Currency = "USD"
            };

            var result = await SendAsync(command);

            var list = await FindAsync<CustomerAccount>(result.Data.Id);

            list.Should().NotBeNull();
            list.CustomerId.Should().Be(command.CustomerId);
            list.Creator.Should().Be(userId);
            list.CreateDate.Should().BeCloseTo(DateTime.Now, 10.Seconds());
        }
    }
}
