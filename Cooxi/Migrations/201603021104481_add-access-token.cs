namespace Cooxi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaccesstoken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AccessToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AccessToken");
        }
    }
}
