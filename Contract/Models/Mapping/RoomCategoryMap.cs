using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class RoomCategoryMap : EntityTypeConfiguration<RoomCategory>
    {
        public RoomCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("RoomCategory", "Configuration");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
        }
    }
}
