using System.Configuration;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JudgeApps.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Booth> Booths { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<JudgeBoothMark> JudgeBoothMark { get; set; }
        public DbSet<Group> Participants { get; set; }
        public DbSet<Participant> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // One-to-Many between GROUP to BOOTH
            modelBuilder
                .Entity<Group>()
                .HasRequired(g => g.Booth)
                .WithMany(b => b.Group)
                .HasForeignKey(g => g.BoothId)
                .WillCascadeOnDelete(false);

            // One-to-Many between GROUP to MARKS
            modelBuilder
                .Entity<Group>()
                .HasMany(g => g.Marks)
                .WithRequired(m => m.Group)
                .HasForeignKey(g => g.GroupId)
                .WillCascadeOnDelete(false);

            // One-to-Many between Group to Participant
            modelBuilder
                .Entity<Participant>()
                .HasRequired(p => p.Group)
                .WithMany(g => g.Participants)
                .HasForeignKey(p => p.GroupId)
                .WillCascadeOnDelete(false);
               
            modelBuilder
                .Entity<JudgeBoothMark>()
                .HasKey(j => new
                {
                    j.JudgeId, j.BoothId 
                });
                
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}