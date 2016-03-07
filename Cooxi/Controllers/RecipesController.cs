using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cooxi.Models;
using IdentitySample.Models;
using Cooxi.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace Cooxi.Controllers
{
    public class RecipesController : Controller
    {
        private CooxiDbContext db = new CooxiDbContext();

        [HttpPost]
        public ActionResult SaveRecipe(SaveRecipeViewModel recipe)
        {
            try
            {
                var rcp = new Recipe()
                {
                    RecipeId = Guid.NewGuid(),
                    InstagramId = recipe.instagramId,
                    Title = recipe.title,
                    Prepare = recipe.prepare,
                    Ration = recipe.ration,
                    Dificulty = recipe.dificulty,
                    MealType = recipe.type
                };

                List<Tag> tagsList = new List<Tag>();
                foreach (var tag in recipe.tags)
                {
                    tagsList.Add(new Tag()
                    {
                        TagId = Guid.NewGuid(),
                        Name = tag
                    });
                }

                rcp.Tags = tagsList;

                string currentUserId = User.Identity.GetUserId();
                rcp.User = db.Users.FirstOrDefault(x => x.Id == currentUserId);

                List<Ingredient> ingList = new List<Ingredient>();
                foreach(var ing in recipe.ingredients)
                {
                    ingList.Add(new Ingredient()
                    {
                        IngredientId = Guid.NewGuid(),
                        Name = ing.name,
                        MeasureUnit = ing.measure,
                        Count = float.Parse(ing.count)
                    });
                }

                rcp.IngredientsList = ingList;
                db.Recipe.Add(rcp);
                db.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    errorMessage = "Nie udało sie dodać przepisu! \nERRORINFO: " + ex.Message
                });
            }
        }

        // GET: Recipes
        public ActionResult Index()
        {
            return View(db.Recipe.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeId,Name,PrepareDescription,ImagePath,Note,ServingFor,Difficulty,MealType")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.RecipeId = Guid.NewGuid();
                db.Recipe.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeId,Name,PrepareDescription,ImagePath,Note,ServingFor,Difficulty,MealType")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Recipe recipe = db.Recipe.Find(id);
            db.Recipe.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
