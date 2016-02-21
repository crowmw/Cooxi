namespace Cooxi.Migrations
{
    using IdentitySample.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentitySample.Models.CooxiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IdentitySample.Models.CooxiDbContext context)
        {
            context.Roles.AddOrUpdate(
                p => p.Name,
                new IdentityRole { Id = "1", Name = "Admin" },
                new IdentityRole { Id = "2", Name = "User" }
                );

            var gramy = new Models.MeasureUnit { MeasureUnitId = Guid.NewGuid(), Name = "Gramów", Grams = 1.0M, Short = "g" };
            context.MeasureUnit.AddOrUpdate(
                p => p.Name,
                gramy,
                new Models.MeasureUnit { MeasureUnitId = Guid.NewGuid(), Name = "£y¿eczka", Grams = 5.0M, Short = "³y¿eczka" },
                new Models.MeasureUnit { MeasureUnitId = Guid.NewGuid(), Name = "£y¿ka", Grams = 15.0M, Short = "³y¿ka" },
                new Models.MeasureUnit { MeasureUnitId = Guid.NewGuid(), Name = "Szklanka", Grams = 250.0M, Short = "szklanka" }
                );

            context.Ingredient.AddOrUpdate(
                p => p.Name,
                new Models.Ingredient { IngredientId = Guid.NewGuid(), Name = "Kurczak", MeasureUnit = gramy },
                new Models.Ingredient { IngredientId = Guid.NewGuid(), Name = "Wo³owina", MeasureUnit = gramy },
                new Models.Ingredient { IngredientId = Guid.NewGuid(), Name = "Wieprzowina", MeasureUnit = gramy },
                new Models.Ingredient { IngredientId = Guid.NewGuid(), Name = "Sól", MeasureUnit = gramy },
                new Models.Ingredient { IngredientId = Guid.NewGuid(), Name = "Pieprz", MeasureUnit = gramy },
                new Models.Ingredient { IngredientId = Guid.NewGuid(), Name = "Ser", MeasureUnit = gramy },
                new Models.Ingredient { IngredientId = Guid.NewGuid(), Name = "Woda",MeasureUnit = gramy },
                new Models.Ingredient { IngredientId = Guid.NewGuid(), Name = "M¹ka", MeasureUnit = gramy }
                );
        }
    }
}
