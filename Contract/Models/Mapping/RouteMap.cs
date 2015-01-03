using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class RouteMap : EntityTypeConfiguration<Route>
    {
        public RouteMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Route", "WorkFlow");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProcessID).HasColumnName("ProcessID");
            this.Property(t => t.ToTask).HasColumnName("ToTask");
            this.Property(t => t.FromTask).HasColumnName("FromTask");

            // Relationships
            this.HasRequired(t => t.Process)
                .WithMany(t => t.Routes)
                .HasForeignKey(d => d.ProcessID);
            this.HasRequired(t => t.Task)
                .WithMany(t => t.Routes)
                .HasForeignKey(d => d.FromTask);
            this.HasRequired(t => t.Task1)
                .WithMany(t => t.Routes1)
                .HasForeignKey(d => d.ToTask);

        }
    }
}
