using AndariaFinHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndariaFinHub.Domain.Entities
{
    public class Customer : AuditableEntity, IHasDomainEvent
    {
        public Customer()
        {
            CustomerAccounts = new List<CustomerAccount>();
            DomainEvents = new List<DomainEvent>();
        }

        public int Id { get; set; }
        public string IdNumber { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    
        public IList<CustomerAccount> CustomerAccounts { get; set; }    
        public List<DomainEvent> DomainEvents { get; set; }
    }
}

//a.ID Card – Maltese ID card validation.
//b. First Name – not more than 20 characters.
//c. Last Name – not more than 20 characters.
//d. Date of birth – Only 18+ candidates can apply.
//e. Email Address – Email regex validation.
//f. Username – not more than 30 characters
//g. Password – more than 8 characters, less than 50, lowercase alpha, uppercase alpha, numeric, symbol.