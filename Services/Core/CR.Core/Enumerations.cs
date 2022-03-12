using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CR.Core
{
    public static class Enumerations
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }
            return value.ToString();
        }

        public enum ReportStatusEnum
        {
            [Description("Bekliyor")] NotReady = 0,
            [Description("Hazırlanıyor")] Processing = 1,
            [Description("Tamamlandı")] Ready = 2
        }

        public enum ContactInfoEnum
        {
            [Description("Telephone")] Mobil = 0,
            [Description("e-Mail")] Mail = 1,
            [Description("Location")] Location = 2
        }
    }
}
