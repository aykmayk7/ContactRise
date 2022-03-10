using System;
using static CR.Core.Enumerations;

namespace Report.Aggregator.Models
{
    public class ReportCreate 
    {
        public ReportCreate()
        {
            this.ReportDate = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public string Id { get; set; }
        public string ReportDate { get; set; }
        public string ReportTarget { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }


    }
}
