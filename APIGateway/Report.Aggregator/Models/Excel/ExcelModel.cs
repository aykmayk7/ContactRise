using System.ComponentModel;

namespace Report.Aggregator.Models.Excel
{
    public class ExcelModel
    {
        [DisplayName("Location Name")]
        public string LocationName { get; set; }

        [DisplayName("Person Count")]
        public long PersonCount { get; set; }

        [DisplayName("Telephone Count")]
        public long TelephoneCount { get; set; }
    }
}
