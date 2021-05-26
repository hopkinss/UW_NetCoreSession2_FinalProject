using Lab.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.UI.ModelWrapper
{
    public class LabTestWrapper : Wrapper<LabTest>
    {
        public LabTestWrapper(LabTest model) : base(model)
        {
        }

        public int Id { get { return Model.Id; } }

        public string TestName
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }
        public int? UnitId
        {
            get { return GetValue<int?>(); }
            set
            {
                SetValue(value);
            }
        }
        public SpecimenType Specimen
        {
            get { return GetValue<SpecimenType>(); }
            set
            {
                SetValue(value);
            }
        }
        public CategoryType Category
        {
            get { return GetValue<CategoryType>(); }
            set
            {
                SetValue(value);
            }
        }


        public int? CdiscTestId
        {
            get { return GetValue<int?>(); }
            set
            {
                SetValue(value);
            }
        }
        public int? CdiscTestNameId
        {
            get { return GetValue<int?>(); }
            set
            {
                SetValue(value);
            }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(TestName):
                    //TODO: add unique check
                    if (string.Equals(TestName, "err", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "TODO";
                    }
                    break;
                case nameof(Specimen):
                    if ((int)Specimen < 0)
                    {
                        yield return "You must select a speciment type";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
