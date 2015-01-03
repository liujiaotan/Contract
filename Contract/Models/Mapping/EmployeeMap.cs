using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RealName)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Mobile)
                .HasMaxLength(11);

            this.Property(t => t.QQ)
                .HasMaxLength(12);

            this.Property(t => t.E_Mail)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Employee", "User");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ServiceCenterID).HasColumnName("ServiceCenterID");
            this.Property(t => t.RealName).HasColumnName("RealName");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.QQ).HasColumnName("QQ");
            this.Property(t => t.E_Mail).HasColumnName("E-Mail");
            this.Property(t => t.IsFreezed).HasColumnName("IsFreezed");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasMany(t => t.Roles)
                .WithMany(t => t.Employees)
                .Map(m =>
                    {
                        m.ToTable("Adlectio", "Relation");
                        m.MapLeftKey("EmployeeID");
                        m.MapRightKey("RoleID");
                    });

            this.HasRequired(t => t.ServiceCenter)
                .WithMany(t => t.Employees)
                .HasForeignKey(d => d.ServiceCenterID);

        }
    }
}
