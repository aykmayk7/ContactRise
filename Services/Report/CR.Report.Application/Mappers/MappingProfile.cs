using AutoMapper;
using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;

namespace CR.Report.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReportCreate, ReportCreate>().ReverseMap();
            CreateMap<ReportCreate, ReportResponse>().ReverseMap();
            CreateMap<ReportInfoCreate, ReportInfoResponse>().ReverseMap();

        }
    }
}
