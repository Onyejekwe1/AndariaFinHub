using AndariaFinHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndariaFinHub.Domain.Entities
{
    public class CustomerAccount : AuditableEntity
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }  
    }
}