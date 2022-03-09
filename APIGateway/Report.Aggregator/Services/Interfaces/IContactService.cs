using Report.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.Aggregator.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactResponse> GetContact(ReportCreate reportCreate);
    }
}
