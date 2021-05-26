using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Lab.Model
{
    public enum SpecimenType { Blood, Serum, Plasma, Urine }
    public enum CategoryType { Chemistry,Coagulation,Hematology,Immunology,Microbiology,Urinalysis}
    public class LabTest
    {
        public LabTest()
        {
            ReferenceRanges = new Collection<LabTestRefRange>();
            Conversions = new Collection<LabTestConversion>();
        }
        
        public int Id { get; set; }
        [Required]
        public string TestName { get; set; }
        
        public SpecimenType Specimen { get; set; }
        public CategoryType Category { get; set; }
        public int? UnitId { get; set; }
        public int? CdiscTestId { get; set; }
        public int? CdiscTestNameId { get; set; }

        public Unit LabTestUnit { get; set; }
        public CdiscTestCd CdiscTestCd { get; set; }
        public CdiscTestName CdiscTestName { get; set; }

        public  ICollection<LabTestRefRange> ReferenceRanges { get; set; }
        public ICollection<LabTestConversion> Conversions { get; set; }

    }
}
