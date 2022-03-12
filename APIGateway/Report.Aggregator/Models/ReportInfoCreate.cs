using System;

namespace Report.Aggregator.Models
{
    public class ReportInfoCreate
    {
  
        public Guid ReportId { get; set; }
        public string ReportName { get; set; }
        public string SavePath { get; set; }

    }
}