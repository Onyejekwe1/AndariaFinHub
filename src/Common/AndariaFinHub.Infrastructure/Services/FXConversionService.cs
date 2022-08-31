using AndariaFinHub.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndariaFinHub.Infrastructure.Services
{
    public class FXConversionService : IFXConversionService
    {
        public const decimal UsdRate = 1.1m;
        public const decimal GbpRate = 0.9m;
        public decimal EuroToGbp(decimal amount)
        {
            return amount * GbpRate;
        }

        public decimal EuroToUsd(decimal amount)
        {
            return amount * UsdRate;
        }
    }
}
