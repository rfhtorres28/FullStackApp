using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

namespace MvcApp.Data {
    
  
    public class ApplicationDbContext : IdentityDbContext<UserDetails> {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

        public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            

            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<UserDetails>(entity =>{
    
                  entity.Property(e => e.ContactNumber).HasColumnName("ContactNumber");
                  entity.Property(e => e.BirthDate).HasColumnName("BirthDate");
                  entity.Property(e => e.FacebookLink).HasColumnName("FacebookLink");
                  entity.Property(e => e.InstagramLink).HasColumnName("InstagramLink");
                  entity.Property(e => e.LastLogin ).HasColumnName("LastLogin");
                });

        }
    }
}
