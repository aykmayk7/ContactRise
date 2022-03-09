using static CR.Core.Enumerations;

namespace EventBus.Events
{
    public class ReportEvent : IntegrationBaseEvent
    {
        public string ReportDate { get; set; }
        public string ReportTarget { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
     
    }
}
