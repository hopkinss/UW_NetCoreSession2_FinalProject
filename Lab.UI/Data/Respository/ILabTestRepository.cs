using Lab.Model;
using Lab.UI.ModelWrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab.UI.Data.Repository
{
    public interface ILabTestRepository
    {
        Task<LabTest> GetByIdAsync(int id);
        Task SaveAsync();
        bool HasChanges();
        void Add(LabTest test);
        void Remove(LabTest model);
        void RemoveReferenceRange(LabTestRefRange model);
    }
}