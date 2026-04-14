using Microsoft.EntityFrameworkCore;

namespace PracticeModelValidation.Data
{
    public class PracticeModelValidationContext : DbContext
    {
        public PracticeModelValidationContext (DbContextOptions<PracticeModelValidationContext> options)
            : base(options)
        {
        }

        public DbSet<PracticeModelValidation.Models.Movie> Movie { get; set; } = default!;
    }
}
