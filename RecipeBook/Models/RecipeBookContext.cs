using Microsoft.EntityFrameworkCore;

namespace RecipeBook.Models
{
  public class RecipeBookContext : DbContext
  {
    public virtual DbSet<Recipe> Recipe { get; set; }
    public DbSet<Tags> Tags { get; set; }
    public DbSet<RecipeTag> RecipeTag { get; set; }

    public RecipeBookContext(DbContextOptions options) : base(options) { }
  }
}