using System;
using AndariaFinHub.Application.Dto;
using AndariaFinHub.Domain.Entities;
using FluentAssertions;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace AndariaFinHub.Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IMapper _mapper;

        public MappingTests()
        {
            TypeAdapterConfig typeAdapterConfig = new TypeAdapterConfig();

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(typeAdapterConfig);
            services.AddScoped<IMapper, ServiceMapper>();

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            _mapper = scope.ServiceProvider.GetService<IMapper>();
        }


        [Test]
        [TestCase(typeof(Customer), typeof(CustomerDto))]
        [TestCase(typeof(CustomerAccount), typeof(CustomerAccountDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }

        [Test]
        public void ShouldMappingCorrectly()
        {
            var city = new Customer { Id = 1, FirstName = "Bursa" };
            var cityDto = _mapper.Map<Customer, CustomerDto>(city);
            cityDto.FirstName.Should().Be("Bursa");
        }
    }
}
