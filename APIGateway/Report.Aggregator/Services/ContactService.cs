using Report.Aggregator.Models;
using Report.Aggregator.Services.Interfaces;
using System.Threading.Tasks;

namespace Report.Aggregator.Services
{
    public class ContactService : IContactService
    {
        public Task<ContactResponse> GetContact(ReportCreate reportCreate)
        {
            throw new System.NotImplementedException();
        }
    }
}
