using AutoMapper;
using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Commands.Delete;
using CR.Contact.Application.Responses;

namespace CR.Contact.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactCreate, ContactCreate>().ReverseMap();
            CreateMap<ContactCreate, ContactDelete>().ReverseMap();
            CreateMap<ContactCreate, ContactResponse>().ReverseMap();

            CreateMap<ContactInfosCreate, ContactInfosCreate>().ReverseMap();
            CreateMap<ContactInfosCreate, ContactInfosDelete>().ReverseMap();
            CreateMap<ContactInfosCreate, ContactInfosResponse>().ReverseMap();
        }
    }
}
