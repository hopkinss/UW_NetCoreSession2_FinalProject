using Lab.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.UI.ModelWrapper
{
    public class LabTestRefernceRangeWrapper : Wrapper<LabTestRefRange>
    {
        public LabTestRefernceRangeWrapper(LabTestRefRange model) : base(model)
        {

        }


        public string Sex
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public double ULN
        {
            get { return GetValue<double>(); }
            set { SetValue(value); }
        }
        public double LLN
        {
            get { return GetValue<double>(); }
            set { SetValue(value); }
        }
    }
}
