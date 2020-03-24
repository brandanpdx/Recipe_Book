using System.Collections.Generic;

namespace RecipeBook.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.Tags = new HashSet<RecipeTag>();
    }
    public int RecipeId { get; set; }
    public string Name { get; set; }
    public int Rating { get; set; }
    public string Instructions { get; set; }
    public string Ingredients { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<RecipeTag> Tags { get; set; }
  }
}