using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeBook.Models;


namespace RecipeBook.Controllers
{
  public class RecipesController : Controller
  {
    private readonly RecipeBookContext _db;

    public RecipesController(RecipeBookContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Recipes.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.Tags = new SpectList(_db.Tags, "TagId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Recipe recipe)
    {
      _db.Recipes.Add(recipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {

      Recipe thisRecipe = _db.Recipes
        .Include(recipe => recipe.Tags)
        .ThenInclude(join => join.Tag)
        .FirstOrDefault(recipe => recipe.RecipeId == id);

      return View(thisRecipe);
      // return View();
    }

    public ActionResult Edit(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult Edit(Recipe recipe)
    {
      _db.Entry(recipe).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      _db.Recipes.Remove(thisRecipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }

}