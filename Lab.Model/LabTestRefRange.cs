using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Model
{
    public class LabTestRefRange
    {
      
        public int Id { get; set; }
        public string Sex { get; set; }
        public double ULN { get; set; }
        public double LLN { get; set; }
        public int LabTestId { get; set; }
        public LabTest LabTest { get; set; }
    }
}
