using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Model
{
    public class LabTestConversion
    {
        public int Id { get; set; }

        public int UnitFromId { get; set; }
        public int UnitToId { get; set; }
        public LabTest LabTest { get; set; }
    }
}
