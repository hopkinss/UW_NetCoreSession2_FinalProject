using Lab.Model;
using Lab.UI.ModelWrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab.UI.Data.Repository
{
    public interface ILabTestRepository : IGenericRespository<LabTest> 
    {
        void RemoveReferenceRange(LabTestRefRange model);
        void RemoveConversion(LabTestConversion model);
        Task<List<LabTest>> GetAllAsync();
    }
}