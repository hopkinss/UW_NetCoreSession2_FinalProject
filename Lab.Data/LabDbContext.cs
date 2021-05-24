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
   
        public DbSet<LabTestRefRange> LabTestRefRanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Lab;Trusted_Connection=True;");
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Unit>().HasData(
                new { Id = 1, Name = "10^6 cell/uL" },
                new { Id = 2, Name = "mg/dL" },
                new { Id = 3, Name = "%" },
                new { Id=4,   Name="ng/dL"} );

            builder.Entity<LabTest>().HasData(
                new { Id = 1, TestName = "Hemoglobin", Unit = "mg/dL", Specimen = SpecimenType.Blood},
                new { Id = 2, TestName = "Hematocrit", Unit = "%", Specimen = SpecimenType.Blood},
                new { Id = 3, TestName = "Red Blood Cell Count", Unit = "10^6/uL", Specimen = SpecimenType.Blood},
                new { Id = 4, TestName = "Calcium", Unit = "mg/dL", Specimen = SpecimenType.Serum });

            builder.Entity<CdiscTestCd>().HasData(
                new { Id = 1, Name = "HGB" },
                new { Id = 2, Name = "HCT" },
                new { Id = 3, Name = "RBC" },
                new { Id = 4, Name = "CA" });


            builder.Entity<LabTestRefRange>().HasData(
            new { Id = 1, LLN = "12.5", ULN = "17.0", LabTestId = 1, Sex = Sex.Male });

        }
    }
}
