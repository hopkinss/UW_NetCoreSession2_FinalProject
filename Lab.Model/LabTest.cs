using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Lab.Model
{
    public enum SpecimenType { Blood, Serum, Plasma, Urine }
    public class LabTest
    {
        public LabTest()
        {
            ReferenceRanges = new Collection<LabTestRefRange>();
        }
        
        public int Id { get; set; }
        [Required]
        public string TestName { get; set; }
        
        public string Unit { get; set; }
        public SpecimenType Specimen { get; set; }
        public int? CdiscTestId { get; set; }
        public CdiscTestCd CdiscTestCd { get; set; }
        public  ICollection<LabTestRefRange> ReferenceRanges { get; set; }
    }
}
