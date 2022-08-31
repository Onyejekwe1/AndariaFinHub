using System;
using System.Threading.Tasks;
using AndariaFinHub.Application.Customers.Queries;
using AndariaFinHub.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static AndariaFinHub.Application.IntegrationTests.Testing;

namespace AndariaFinHub.Application.IntegrationTests.Cities.Queries
{
    public class GetAllCustomersTests : TestBase    
    {
        [Test]
        public async Task ShouldReturnAllCities()
        {
            await AddAsync(new Customer
            {
                FirstName = "Test Name",
                LastName = "Last Name",
                DateOfBirth = DateTime.Now.AddYears(-22),
                EmailAddress = "ifeanyi2_test@yahoo.com",
                Username = "testUser2",
                Password = "Laporta1.!",
                IdNumber = "M7386272"
            });

            var query = new GetAllCustomersQuery(); 

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Data.Count.Should().BeGreaterThan(0);
        }
    }
}