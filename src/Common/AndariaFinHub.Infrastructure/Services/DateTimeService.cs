using System;
using AndariaFinHub.Application.Common.Interfaces;

namespace AndariaFinHub.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
