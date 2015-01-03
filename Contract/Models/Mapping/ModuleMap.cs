using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class ModuleMap : EntityTypeConfiguration<Module>
    {
        public ModuleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FunctionID, t.OperationID });

            // Properties
            // Table & Column Mappings
            this.ToTable("Module", "Configuration");
            this.Property(t => t.FunctionID).HasColumnName("FunctionID");
            this.Property(t => t.OperationID).HasColumnName("OperationID");

            // Relationships
            this.HasMany(t => t.Roles)
                .WithMany(t => t.Modules)
                .Map(m =>
                    {
                        m.ToTable("Permission", "Permission");
                        m.MapLeftKey("FunctionID", "OperationID");
                        m.MapRightKey("RoleID");
                    });

            this.HasRequired(t => t.Function)
                .WithMany(t => t.Modules)
                .HasForeignKey(d => d.FunctionID);
            this.HasRequired(t => t.Operation)
                .WithMany(t => t.Modules)
                .HasForeignKey(d => d.OperationID);

        }
    }
}
