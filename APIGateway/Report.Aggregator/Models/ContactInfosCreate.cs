using System;

namespace Report.Aggregator.Models
{
    public class ContactInfosCreate
    {
        public Guid Id { get; set; }

        public string ContactId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Contents { get; set; }
    }
}
