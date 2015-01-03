using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        public RoomMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Number)
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Room", "Configuration");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ServiceCenterID).HasColumnName("ServiceCenterID");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Floor).HasColumnName("Floor");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.Space).HasColumnName("Space");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");

            // Relationships
            this.HasMany(t => t.Tenancies)
                .WithMany(t => t.Rooms)
                .Map(m =>
                    {
                        m.ToTable("Renting", "Relation");
                        m.MapLeftKey("RoomID");
                        m.MapRightKey("TenancyID");
                    });

            this.HasRequired(t => t.RoomCategory)
                .WithMany(t => t.Rooms)
                .HasForeignKey(d => d.Category);
            this.HasRequired(t => t.RoomState)
                .WithMany(t => t.Rooms)
                .HasForeignKey(d => d.State);
            this.HasRequired(t => t.RoomType)
                .WithMany(t => t.Rooms)
                .HasForeignKey(d => d.Type);
            this.HasRequired(t => t.ServiceCenter)
                .WithMany(t => t.Rooms)
                .HasForeignKey(d => d.ServiceCenterID);

        }
    }
}
