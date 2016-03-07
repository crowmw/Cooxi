namespace Cooxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class singlepagechanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "MeasureUnit_MeasureUnitId", "dbo.MeasureUnits");
            DropForeignKey("dbo.Recipes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Ingredients", new[] { "MeasureUnit_MeasureUnitId" });
            DropIndex("dbo.Recipes", new[] { "User_Id" });
            AddColumn("dbo.Ingredients", "Count", c => c.Single(nullable: false));
            AddColumn("dbo.Recipes", "InstagramId", c => c.String());
            AddColumn("dbo.Recipes", "Title", c => c.String());
            AddColumn("dbo.Recipes", "Prepare", c => c.String());
            AddColumn("dbo.Recipes", "Ration", c => c.String());
            AddColumn("dbo.Recipes", "Dificulty", c => c.String());
            AlterColumn("dbo.Ingredients", "Name", c => c.String());
            AlterColumn("dbo.Ingredients", "MeasureUnit_MeasureUnitId", c => c.Guid());
            AlterColumn("dbo.MeasureUnits", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Recipes", "MealType", c => c.String());
            AlterColumn("dbo.Recipes", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ingredients", "MeasureUnit_MeasureUnitId");
            CreateIndex("dbo.Recipes", "User_Id");
            AddForeignKey("dbo.Ingredients", "MeasureUnit_MeasureUnitId", "dbo.MeasureUnits", "MeasureUnitId");
            AddForeignKey("dbo.Recipes", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Recipes", "Name");
            DropColumn("dbo.Recipes", "PrepareDescription");
            DropColumn("dbo.Recipes", "ImagePath");
            DropColumn("dbo.Recipes", "Note");
            DropColumn("dbo.Recipes", "ServingFor");
            DropColumn("dbo.Recipes", "Difficulty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Difficulty", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "ServingFor", c => c.String(nullable: false));
            AddColumn("dbo.Recipes", "Note", c => c.String());
            AddColumn("dbo.Recipes", "ImagePath", c => c.String(nullable: false));
            AddColumn("dbo.Recipes", "PrepareDescription", c => c.String(nullable: false));
            AddColumn("dbo.Recipes", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Recipes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ingredients", "MeasureUnit_MeasureUnitId", "dbo.MeasureUnits");
            DropIndex("dbo.Recipes", new[] { "User_Id" });
            DropIndex("dbo.Ingredients", new[] { "MeasureUnit_MeasureUnitId" });
            AlterColumn("dbo.Recipes", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Recipes", "MealType", c => c.Int(nullable: false));
            AlterColumn("dbo.MeasureUnits", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Ingredients", "MeasureUnit_MeasureUnitId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Ingredients", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Recipes", "Dificulty");
            DropColumn("dbo.Recipes", "Ration");
            DropColumn("dbo.Recipes", "Prepare");
            DropColumn("dbo.Recipes", "Title");
            DropColumn("dbo.Recipes", "InstagramId");
            DropColumn("dbo.Ingredients", "Count");
            CreateIndex("dbo.Recipes", "User_Id");
            CreateIndex("dbo.Ingredients", "MeasureUnit_MeasureUnitId");
            AddForeignKey("dbo.Recipes", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ingredients", "MeasureUnit_MeasureUnitId", "dbo.MeasureUnits", "MeasureUnitId", cascadeDelete: true);
        }
    }
}
