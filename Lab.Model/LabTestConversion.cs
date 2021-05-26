using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Model
{
    public class LabTestConversion
    {
        public int Id { get; set; }

        public int UnitFromId { get; set; }
        public Unit UnitFrom { get; set; }
        public int UnitToId { get; set; }
        public Unit UnitTo { get; set; }
        public string ConFac { get; set; }
        public int LabTestId { get; set; }
        public LabTest LabTest { get; set; }
    }
}
