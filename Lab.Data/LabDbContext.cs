using Lab.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Data
{
    public class LabDbContext : DbContext
    {

        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<CdiscTestCd> CdiscTestCds { get; set; }
        public DbSet<CdiscTestName> CdiscTest { get; set; }
        public DbSet<LabTestRefRange> LabTestRefRanges { get; set; }
        public DbSet<LabTestConversion> LabTestConversions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Lab;Trusted_Connection=True;");
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity("Lab.Model.LabTestConversion", b =>
            {
                b.HasOne("Lab.Model.Unit", "UnitFrom")
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired()
                    .HasForeignKey("UnitFromId");

                b.HasOne("Lab.Model.Unit", "UnitTo")
                    .WithMany()
                    .HasForeignKey("UnitToId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();
            });




            builder.Entity<CdiscTestCd>().HasData(
                new { Id = 1, Name = "HGB" },
                new { Id = 2, Name = "HCT" },
                new { Id = 3, Name = "PROT" },
                new { Id = 4, Name = "CA" });

            builder.Entity<CdiscTestName>().HasData(
                new { Id = 1, Name = "Hemoglobin" },
                new { Id = 2, Name = "Hematocrit" },
                new { Id = 3, Name = "Protein" },
                new { Id = 4, Name = "Calcium" });

            builder.Entity<LabTestRefRange>().HasData(
                new { Id = 1, LLN = "11.5", ULN = "15.0", LabTestId = 1, Sex = Sex.Male },
                new { Id = 2, LLN = "10", ULN = "14.0", LabTestId = 1, Sex = Sex.Female },
                new { Id = 3, LLN = "35", ULN = "45", LabTestId = 2, Sex = Sex.Male },
                new { Id = 4, LLN = "33", ULN = "43", LabTestId = 2, Sex = Sex.Female },
                new { Id = 5, LLN = "5", ULN = "25", LabTestId = 3, Sex = Sex.Female },
                new { Id = 6, LLN = "5", ULN = "24", LabTestId = 3, Sex = Sex.Male },
                new { Id = 7, LLN = "8.5", ULN = "10.5", LabTestId = 4, Sex = Sex.All }
            );

            builder.Entity<Unit>().HasData(
                new { Id = 1, Name = "g/L" },
                new { Id = 2, Name = "mg/dL" },
                new { Id = 3, Name = "%" },
                new { Id = 4, Name = "ng/dL" },
                new { Id = 5, Name = "mmol/L" },
                new { Id = 6, Name = "g/dL" });

            builder.Entity<LabTest>().HasData(
                new { Id = 1, TestName = "Hemoglobin", Unit = "mg/dL", Specimen = SpecimenType.Blood, Category = CategoryType.Hematology },
                new { Id = 2, TestName = "Hematocrit", Unit = "%", Specimen = SpecimenType.Blood, Category = CategoryType.Hematology },
                new { Id = 3, TestName = "Urine Protein", Unit = "g/L", Specimen = SpecimenType.Urine, Category = CategoryType.Urinalysis },
                new { Id = 4, TestName = "Calcium (Non-Ionized)", Unit = "mg/dL", Specimen = SpecimenType.Serum, Category = CategoryType.Chemistry });


            builder.Entity<LabTestConversion>().HasData(
                new { Id = 1, UnitFromId = 1, UnitToId = 2, ConFac = "100", LabTestId = 1 },
                new { Id = 2, UnitFromId = 1, UnitToId = 6, ConFac = "10", LabTestId = 1 },
                new { Id = 3, UnitFromId = 1, UnitToId = 2, ConFac = "100", LabTestId = 3 },
                new { Id = 4, UnitFromId = 1, UnitToId = 6, ConFac = "10", LabTestId = 3 },
                new { Id = 5, UnitFromId = 5, UnitToId = 2, ConFac = ".25", LabTestId = 4 },
                new { Id = 6, UnitFromId = 5, UnitToId = 6, ConFac = "2.5", LabTestId = 4 },
                new { Id = 7, UnitFromId = 1, UnitToId = 6, ConFac = "10", LabTestId = 4 }

                );
        }
    }
}
