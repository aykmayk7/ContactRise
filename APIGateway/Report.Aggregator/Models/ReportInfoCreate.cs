using System;

namespace Report.Aggregator.Models
{
    public class ReportInfoCreate
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int TelephoneCount { get; set; }
        public string CreatedTime { get; set; }
    }
}
