using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.Common.Interfaces
{
    public interface IFXConversionService
    {
        decimal EuroToUsd(decimal amount);
        decimal EuroToGbp(decimal amount);    
    }
}
