using UserManagement.Application.AutoMapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(AddressProfile),
                typeof(ContactProfile),
                typeof(DocumentProfile),
                typeof(UserProfile));
        }
    }
}