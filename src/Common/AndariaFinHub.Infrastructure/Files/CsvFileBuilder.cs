using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using AndariaFinHub.Application.Common.Interfaces;
using AndariaFinHub.Application.Dto;
using AndariaFinHub.Infrastructure.Files.Maps;
using CsvHelper;

namespace AndariaFinHub.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildAccountTransactionsFile(IEnumerable<CustomerAccountDto> customerAccounts)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Context.RegisterClassMap<CustomerAccountMap>();
                csvWriter.WriteRecords(customerAccounts);
            }

            return memoryStream.ToArray();
        }
    }
}
