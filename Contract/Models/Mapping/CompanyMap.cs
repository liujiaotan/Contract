using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.TaxNumber)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.BusinessNumber)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.JuridicalPerson)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Produce)
                .HasMaxLength(400);

            this.Property(t => t.Need)
                .HasMaxLength(400);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.HomePage)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Company", "Client");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TaxNumber).HasColumnName("TaxNumber");
            this.Property(t => t.BusinessNumber).HasColumnName("BusinessNumber");
            this.Property(t => t.JuridicalPerson).HasColumnName("JuridicalPerson");
            this.Property(t => t.Produce).HasColumnName("Produce");
            this.Property(t => t.Need).HasColumnName("Need");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.HomePage).HasColumnName("HomePage");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
        }
    }
}
