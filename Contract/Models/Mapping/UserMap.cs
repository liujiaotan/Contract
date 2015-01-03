using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.PassWord)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("User", "User");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.PassWord).HasColumnName("PassWord");

            // Relationships
            this.HasRequired(t => t.Employee)
                .WithOptional(t => t.User);

        }
    }
}
