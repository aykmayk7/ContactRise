using System;
using static CR.Core.Enumerations;

namespace Report.Aggregator.Models
{
    public class ContactInfosCreate
    {
        public Guid Id { get; set; }

        public Guid ContactId { get; set; }

        public ContactInfoEnum Info { get; set; }

        public string Value { get; set; }

        public string Contents { get; set; }
    }
}