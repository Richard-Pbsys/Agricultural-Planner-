using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VHS.Data.Models.Batches;

namespace VHS.Data.Mappings
{
    public class BatchConfigurationMap : IEntityTypeConfiguration<BatchConfiguration>
    {
        public void Configure(EntityTypeBuilder<BatchConfiguration> builder)
        {
            builder.ToTable("BatchConfigurations");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasOne(b => b.Farm)
                   .WithMany()
                   .HasForeignKey(b => b.FarmId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Recipe)
                   .WithMany(r => r.BatchConfigurations)
                   .HasForeignKey(b => b.RecipeId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(b => b.Batches)
                   .WithOne(b => b.BatchConfiguration)
                   .HasForeignKey(b => b.BatchConfigurationId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(b => b.TotalTrays).IsRequired();
            builder.Property(b => b.TraysPerDay).IsRequired();
            builder.Property(b => b.StartTime).IsRequired(false);
            builder.Property(b => b.EndTime).IsRequired(false);

            builder.Property(b => b.AddedDateTime)
                   .IsRequired();

            builder.Property(b => b.ModifiedDateTime)
                   .IsRequired();

            builder.Property(b => b.DeletedDateTime)
                   .IsRequired(false);
        }
    }
}
