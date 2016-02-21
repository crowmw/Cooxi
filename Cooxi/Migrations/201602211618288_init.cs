namespace Cooxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        MeasureUnit_MeasureUnitId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientId)
                .ForeignKey("dbo.MeasureUnits", t => t.MeasureUnit_MeasureUnitId, cascadeDelete: true)
                .Index(t => t.MeasureUnit_MeasureUnitId);
            
            CreateTable(
                "dbo.MeasureUnits",
                c => new
                    {
                        MeasureUnitId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Short = c.String(nullable: false),
                        Grams = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MeasureUnitId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        PrepareDescription = c.String(nullable: false),
                        ImagePath = c.String(nullable: false),
                        Note = c.String(),
                        ServingFor = c.String(nullable: false),
                        Difficulty = c.Int(nullable: false),
                        MealType = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        Recipe_RecipeId = c.Guid(nullable: false),
                        Ingredient_IngredientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_RecipeId, t.Ingredient_IngredientId })
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_IngredientId, cascadeDelete: true)
                .Index(t => t.Recipe_RecipeId)
                .Index(t => t.Ingredient_IngredientId);
            
            CreateTable(
                "dbo.TagRecipes",
                c => new
                    {
                        Tag_TagId = c.Guid(nullable: false),
                        Recipe_RecipeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Recipe_RecipeId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Recipe_RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Recipes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TagRecipes", "Recipe_RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.TagRecipes", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.RecipeIngredients", "Ingredient_IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeIngredients", "Recipe_RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "MeasureUnit_MeasureUnitId", "dbo.MeasureUnits");
            DropIndex("dbo.TagRecipes", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.TagRecipes", new[] { "Tag_TagId" });
            DropIndex("dbo.RecipeIngredients", new[] { "Ingredient_IngredientId" });
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Recipes", new[] { "User_Id" });
            DropIndex("dbo.Ingredients", new[] { "MeasureUnit_MeasureUnitId" });
            DropTable("dbo.TagRecipes");
            DropTable("dbo.RecipeIngredients");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tags");
            DropTable("dbo.Recipes");
            DropTable("dbo.MeasureUnits");
            DropTable("dbo.Ingredients");
        }
    }
}
