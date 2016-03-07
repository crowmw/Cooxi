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
        }
    }
}
