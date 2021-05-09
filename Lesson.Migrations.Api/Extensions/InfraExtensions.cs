namespace Lesson.Migrations.Api.Extensions
{
    using Abstraction.Configurations;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class InfraExtensions
    {
        public static IServiceCollection ConfigureInfra(this IServiceCollection services, IConfiguration configuration)
        {
            var lessonConfigurations = new LessonConfigurations();
            configuration.Bind("Lesson", lessonConfigurations);
            services.AddSingleton(lessonConfigurations);
            return services;
        }
    }
}