using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Contract.Models.Mapping
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RealName)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Line)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Mobile)
                .HasMaxLength(11);

            this.Property(t => t.Position)
                .HasMaxLength(20);

            this.Property(t => t.QQ)
                .HasMaxLength(15);

            this.Property(t => t.E_Mail)
                .HasMaxLength(30);

            this.Property(t => t.MSN)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Contact", "Client");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.RealName).HasColumnName("RealName");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.Line).HasColumnName("Line");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.QQ).HasColumnName("QQ");
            this.Property(t => t.E_Mail).HasColumnName("E-Mail");
            this.Property(t => t.MSN).HasColumnName("MSN");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");

            // Relationships
            this.HasRequired(t => t.Company)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
