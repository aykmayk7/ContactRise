using System;
using System.Collections.Generic;

namespace Report.Aggregator.Models
{
    public class ContactWithInfoCreate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }
        public ICollection<ContactInfosCreate> ContactInfo { get; set; }
    }
}
