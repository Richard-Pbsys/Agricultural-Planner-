using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VHS.Data.Models.Batches;

namespace VHS.Data.Mappings
{
    public class BatchJournalMap : IEntityTypeConfiguration<BatchJournal>
    {
        public void Configure(EntityTypeBuilder<BatchJournal> builder)
        {
            builder.ToTable("BatchJournals");
            builder.HasKey(bj => bj.Id);
            builder.Property(bj => bj.Id).ValueGeneratedOnAdd();

            builder.Property(bj => bj.BatchId)
                   .IsRequired();

            builder.Property(bj => bj.SeedSupplier)
                   .IsRequired()
                   .HasMaxLength(255);
            builder.Property(bj => bj.SeedLotNumber)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(bj => bj.PeatSupplier)
                   .HasMaxLength(255);
            builder.Property(bj => bj.PeatPrescription)
                   .HasMaxLength(255);
            builder.Property(bj => bj.PeatLotNumber)
                   .HasMaxLength(255);

            builder.Property(bj => bj.RemarksGermination)
                   .HasMaxLength(1000);
            builder.Property(bj => bj.RemarksYoungPlants)
                   .HasMaxLength(1000);
            builder.Property(bj => bj.RemarksIntermediatePlants)
                   .HasMaxLength(1000);
            builder.Property(bj => bj.RemarksHarvestPlants)
                   .HasMaxLength(1000);

            builder.Property(bj => bj.PrognosisGermination)
                   .IsRequired();
            builder.Property(bj => bj.PrognosisDays)
                   .IsRequired();
            builder.Property(bj => bj.PrognosisHeight)
                   .IsRequired();
            builder.Property(bj => bj.PrognosisWeight)
                   .IsRequired();
            builder.Property(bj => bj.PrognosisRootLength)
                   .IsRequired();
            builder.Property(bj => bj.PrognosisRootNeckDiameter)
                   .IsRequired();

            builder.Property(bj => bj.YieldLettuceCount)
                   .IsRequired();
            builder.Property(bj => bj.YieldLettuceWeight)
                   .IsRequired();
            builder.Property(bj => bj.YieldLettuceHeight)
                   .IsRequired();

            builder.Property(bj => bj.YieldPetiteCount)
                   .IsRequired();
            builder.Property(bj => bj.YieldPetiteWeight)
                   .IsRequired();
            builder.Property(bj => bj.YieldPetiteHeight)
                   .IsRequired();

            builder.Property(bj => bj.YieldMicroCount)
                   .IsRequired();
            builder.Property(bj => bj.YieldMicroWeight)
                   .IsRequired();
            builder.Property(bj => bj.YieldMicroHeight)
                   .IsRequired();

            builder.Property(bj => bj.YieldComparison)
                   .HasMaxLength(255);
            builder.Property(bj => bj.MiscellaneousComments)
                   .HasMaxLength(1000);

            builder.Property(bj => bj.AddedDateTime)
                   .IsRequired();
            builder.Property(bj => bj.ModifiedDateTime)
                   .IsRequired();
            builder.Property(bj => bj.DeletedDateTime)
                   .IsRequired(false);
        }
    }
}
