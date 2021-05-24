using Lab.Model;
using Lab.UI.ModelWrapper;
using System.Collections.Generic;

namespace Lab.UI.Data.Repository
{
    public interface ILabTestRepository : IGenericRespository<LabTest> 
    {
        void RemoveReferenceRange(LabTestRefRange model);
    }
}