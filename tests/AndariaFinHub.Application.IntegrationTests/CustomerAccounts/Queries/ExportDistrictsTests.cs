using System;
using AndariaFinHub.Application.Common.Security;
using AndariaFinHub.Application.Districts.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace AndariaFinHub.Application.IntegrationTests.Districts.Queries
{
    using static Testing;

    public class ExportDistrictsTests : TestBase
    {
        [Test]
        public void ShouldDenyAnonymousUser()
        {
            var query = new ExportCustomerAccountStatementQuery();

            query.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();

            FluentActions.Invoking(() =>
                SendAsync(query)).Should().ThrowAsync<UnauthorizedAccessException>();
        }
    }
}
