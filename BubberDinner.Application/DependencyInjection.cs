using BubberDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace BubberDinner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            return services;
        }
    }
}
