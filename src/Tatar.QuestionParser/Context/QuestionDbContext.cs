using Microsoft.EntityFrameworkCore;
using Tatar.Services.Questions;

namespace Tatar.QuestionParser.Context
{
    /// <inheritdoc />
    /// <summary>
    /// Контекст БД EF
    /// </summary>
    public class QuestionDbContext : DbContext
    {
        public QuestionDbContext(DbContextOptions<QuestionDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        /// <summary>
        /// Вопросы
        /// </summary>
        public DbSet<Question> Questions { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Question>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }

    }
}
