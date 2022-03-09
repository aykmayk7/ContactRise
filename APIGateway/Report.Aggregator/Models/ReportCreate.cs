using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CR.Core.Enumerations;

namespace Report.Aggregator.Models
{
    public class ReportCreate 
    {
    
        public string Id { get; set; }

        public string ReportDate { get; set; }
        public string ReportTarget { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }




    }
}
