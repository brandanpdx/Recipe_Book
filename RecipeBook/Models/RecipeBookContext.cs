using Microsoft.EntityFrameworkCore;

namespace RecipeBook.Models
{
  public class RecipeBookContext : DbContext
  {
    public virtual DbSet<Recipe> Recipes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<RecipeTag> RecipeTag { get; set; }

    public RecipeBookContext(DbContextOptions options) : base(options) { }
  }
}