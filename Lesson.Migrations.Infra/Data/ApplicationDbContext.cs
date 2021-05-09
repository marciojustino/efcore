namespace Lesson.Migrations.Infra.Data
{
    using Abstraction.Configurations;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        private readonly LessonConfigurations _lessonConfigurations;
        
        public ApplicationDbContext(LessonConfigurations lessonConfigurations)
        {
            _lessonConfigurations = lessonConfigurations;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_lessonConfigurations.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}