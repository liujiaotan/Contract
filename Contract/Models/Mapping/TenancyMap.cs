using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class TenancyMap : EntityTypeConfiguration<Tenancy>
    {
        public TenancyMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Number)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Tenancy", "Contract");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ServiceCenterID).HasColumnName("ServiceCenterID");
            this.Property(t => t.ProcessID).HasColumnName("ProcessID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.UnitCost).HasColumnName("UnitCost");
            this.Property(t => t.ServiceFee).HasColumnName("ServiceFee");
            this.Property(t => t.HeatingFee).HasColumnName("HeatingFee");
            this.Property(t => t.ElectricityRate).HasColumnName("ElectricityRate");
            this.Property(t => t.LeaseTerm).HasColumnName("LeaseTerm");
            this.Property(t => t.EffectDate).HasColumnName("EffectDate");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");

            // Relationships
            this.HasRequired(t => t.Company)
                .WithMany(t => t.Tenancies)
                .HasForeignKey(d => d.CompanyID);
            this.HasRequired(t => t.ServiceCenter)
                .WithMany(t => t.Tenancies)
                .HasForeignKey(d => d.ServiceCenterID);
            this.HasRequired(t => t.Process)
                .WithMany(t => t.Tenancies)
                .HasForeignKey(d => d.ProcessID);

        }
    }
}
