namespace Cooxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinstauseridname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "InstaUserId", c => c.String());
            AddColumn("dbo.AspNetUsers", "InstaUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "InstaUserName");
            DropColumn("dbo.AspNetUsers", "InstaUserId");
        }
    }
}
