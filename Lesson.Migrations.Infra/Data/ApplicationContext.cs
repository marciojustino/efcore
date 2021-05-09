namespace Lesson.Migrations.Infra.Data
{
    using Abstraction.Configurations;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        private readonly LessonConfigurations _lessonConfigurations;
        
        public DbSet<Account> Account { get; set; }

        public ApplicationContext(LessonConfigurations lessonConfigurations)
        {
            _lessonConfigurations = lessonConfigurations;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_lessonConfigurations.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}