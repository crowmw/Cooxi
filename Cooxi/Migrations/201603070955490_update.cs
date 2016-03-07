namespace Cooxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "MeasureUnit_MeasureUnitId", "dbo.MeasureUnits");
            DropIndex("dbo.Ingredients", new[] { "MeasureUnit_MeasureUnitId" });
            AddColumn("dbo.Ingredients", "MeasureUnit", c => c.String());
            DropColumn("dbo.Ingredients", "MeasureUnit_MeasureUnitId");
            DropTable("dbo.MeasureUnits");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MeasureUnits",
                c => new
                    {
                        MeasureUnitId = c.Guid(nullable: false),
                        Name = c.Int(nullable: false),
                        Short = c.String(nullable: false),
                        Grams = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MeasureUnitId);
            
            AddColumn("dbo.Ingredients", "MeasureUnit_MeasureUnitId", c => c.Guid());
            DropColumn("dbo.Ingredients", "MeasureUnit");
            CreateIndex("dbo.Ingredients", "MeasureUnit_MeasureUnitId");
            AddForeignKey("dbo.Ingredients", "MeasureUnit_MeasureUnitId", "dbo.MeasureUnits", "MeasureUnitId");
        }
    }
}
