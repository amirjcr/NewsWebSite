using Microsoft.Extensions.DependencyInjection;
using NewsWebsite.Data.Contracts;
using NewsWebsite.Data.Repositories;
using NewsWebsite.Data.UnitOfWork;
using NewsWebsite.Services;
using NewsWebsite.Services.Api;
using NewsWebsite.Services.Api.Contract;
using NewsWebsite.Services.Contracts;

namespace NewsWebsite.IocConfig
{
    public static class AddCustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<SendWeeklyNewsletter>();
            services.AddTransient<IjwtService, jwtService>();
            return services;
        }
    }
}
