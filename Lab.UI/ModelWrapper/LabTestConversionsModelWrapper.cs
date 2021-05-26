using System;
using System.Collections.Generic;
using System.Text;
using Lab.Model;

namespace Lab.UI.ModelWrapper
{
    public class LabTestConversionsWrapper : Wrapper<LabTestConversion>
    {
        public LabTestConversionsWrapper(LabTestConversion model) : base(model) 
        {
        }

        public int UnitFromId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public int UnitToId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public string ConFac
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

    }
}
