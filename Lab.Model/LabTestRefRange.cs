using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Model
{
    public enum Sex {All=0, Male,Female}
    public class LabTestRefRange
    {
      
        public int Id { get; set; }
        public Sex Sex { get; set; }
        public string ULN { get; set; }
        public string LLN { get; set; }
        public int LabTestId { get; set; }
        public LabTest LabTest { get; set; }
    }
}
