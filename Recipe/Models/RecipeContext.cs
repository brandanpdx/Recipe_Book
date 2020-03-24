using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Models
{
  public class UniversityRegistrarContext : DbContext
  {
    public virtual DbSet<Recipe> Recipe { get; set; }
    public DbSet<Tags> Tags { get; set; }
    public DbSet<RecipeTag> RecipeTag { get; set; }

    public UniversityRegistrarContext(DbContextOptions options) : base(options) { }
  }
}