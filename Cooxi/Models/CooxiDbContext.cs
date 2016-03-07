using Cooxi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    public class CooxiDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        public CooxiDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static CooxiDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role

        
        Database.SetInitializer<CooxiDbContext>(new ApplicationDbInitializer());
        }

        public static CooxiDbContext Create()
        {
            return new CooxiDbContext();
        }
    }
}