using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace track_a_report_service.Data
{
    public partial class InthubContext : DbContext
    {
        public InthubContext()
        {
        }

        public InthubContext(DbContextOptions<InthubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetEnquiries> AssetEnquiries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetEnquiries>(entity =>
            {
                entity.Property(e => e.AssetId).HasMaxLength(255);

                entity.Property(e => e.AssetType).HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExternalReference).HasMaxLength(24);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
