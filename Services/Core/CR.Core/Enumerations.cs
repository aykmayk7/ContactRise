using System.ComponentModel;

namespace CR.Core
{
    public static class Enumerations
    {
        public enum ReportStatusEnum
        {
            [Description("Hazırlanıyor")] NotReady = 0,
            [Description("Tamamlandı")] Ready = 1
        }
    }
}
