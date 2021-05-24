using Lab.Data;
using Lab.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.UI.Data.Repository
{
    public class LabTestRepository : ILabTestRepository
    {
        private LabDbContext _context;

        public LabTestRepository(LabDbContext context)
        {
            _context = context;
        }

        public void Add(LabTest test)
        {
            _context.LabTests.Add(test);
        }

        public async Task<LabTest> GetByIdAsync(int id)
        {
            return await _context.LabTests.Include(x => x.ReferenceRanges).SingleAsync(x => x.Id == id); 
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Remove(LabTest model)
        {
            _context.LabTests.Remove(model);
        }

        public void RemoveReferenceRange(LabTestRefRange model)
        {
            _context.LabTestRefRanges.Remove(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();            
        }


    }
}
