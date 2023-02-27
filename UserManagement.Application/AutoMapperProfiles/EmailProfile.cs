using AutoMapper;
using UserManagement.Application.DTOs;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.AutoMapperProfiles
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<Email, string>().ConvertUsing(e => e.Value);
            CreateMap<string, Email>().ConvertUsing(s => new Email(s));
        }
    }
}
