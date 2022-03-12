namespace Report.Aggregator.Models
{
    public class ContactByLocationCreate
    {
        public string LocationName { get; set; }
        public int PersonCount { get; set; }
        public int TelephoneCount { get; set; }
    }
}