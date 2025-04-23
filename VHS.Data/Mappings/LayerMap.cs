using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VHS.Data.Models.Farming;

namespace VHS.Data.Mappings
{
    public class LayerMap : IEntityTypeConfiguration<Layer>
    {
        public void Configure(EntityTypeBuilder<Layer> builder)
        {
            builder.ToTable("Layers");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();

            builder.Property(l => l.RackId).IsRequired();
            builder.Property(l => l.LayerNumber).IsRequired();

            builder.Property(l => l.AddedDateTime).IsRequired();
            builder.Property(l => l.DeletedDateTime).IsRequired(false);
        }
    }
}
