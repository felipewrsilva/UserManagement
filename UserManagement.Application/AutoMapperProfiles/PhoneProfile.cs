using AutoMapper;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.AutoMapperProfiles
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<Phone, string>().ConvertUsing(p => p.Value);
            CreateMap<string, Phone>().ConvertUsing(s => new Phone(s));
        }
    }
}
