using System;
using System.Threading.Tasks;
using AndariaFinHub.Application.Common.Exceptions;
using AndariaFinHub.Application.Customers.Commands.Create;
using AndariaFinHub.Domain.Entities;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using static AndariaFinHub.Application.IntegrationTests.Testing;

namespace AndariaFinHub.Application.IntegrationTests.Cities.Commands
{
    public class CreateCustomerTests : TestBase 
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateCustomerCommand();  

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();

        }

        [Test]
        public async Task ShouldRequireAbove18YearsOfAge()  
        {

            var command = new CreateCustomerCommand
            {
                FirstName = "Test Name",
                LastName = "Last Name",
                DateOfBirth = DateTime.Now,
                EmailAddress = "ifeanyi_test@yahoo.com",
                Username = "testUser",
                Password = "Laporta1.!",
                IdNumber = "M7386271"
            };

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateCity()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateCustomerCommand
            {
                FirstName = "Test Name",
                LastName = "Last Name",
                DateOfBirth = DateTime.Now.AddYears(-22),
                EmailAddress = "ifeanyi_test@yahoo.com",
                Username = "testUser",
                Password = "Laporta1.!",
                IdNumber = "M7386271"
            };

            var result = await SendAsync(command);

            var list = await FindAsync<Customer>(result.Data.Id);

            list.Should().NotBeNull();
            list.FirstName.Should().Be(command.FirstName);
            list.Creator.Should().Be(userId);
            list.CreateDate.Should().BeCloseTo(DateTime.Now, 10.Seconds());
        }
    }
}
