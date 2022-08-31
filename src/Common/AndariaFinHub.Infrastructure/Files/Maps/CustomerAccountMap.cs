using System.Globalization;
using AndariaFinHub.Application.Dto;
using CsvHelper.Configuration;

namespace AndariaFinHub.Infrastructure.Files.Maps
{
    public sealed class CustomerAccountMap : ClassMap<CustomerAccountDto>
    {
        public CustomerAccountMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}
