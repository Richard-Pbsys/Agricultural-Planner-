using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VHS.Data.Models.Farming;

namespace VHS.Data.Mappings
{
    public class TrayMap : IEntityTypeConfiguration<Tray>
    {
        public void Configure(EntityTypeBuilder<Tray> builder)
        {
            builder.ToTable("Trays");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.Property(t => t.FarmId).IsRequired();
            builder.HasOne(t => t.Farm)
                   .WithMany()
                   .HasForeignKey(t => t.FarmId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(t => t.RFIDTag)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(t => t.StatusId).IsRequired();

            builder.Property(t => t.AddedDateTime).IsRequired();
            builder.Property(t => t.DeletedDateTime).IsRequired(false);
        }
    }
}
