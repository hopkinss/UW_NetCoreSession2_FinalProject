using Lab.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.UI.ModelWrapper
{
    public class LabTestRefernceRangeWrapper : Wrapper<LabTestRefRange>
    {
        public LabTestRefernceRangeWrapper(LabTestRefRange model) : base(model) { }

        public Sex Sex
        {
            get { return GetValue<Sex>(); }
            set { SetValue(value); }
        }
        public string ULN
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string LLN
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
