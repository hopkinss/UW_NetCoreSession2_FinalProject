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


    public class LabTestRepository : GenericRespository<LabTest,LabDbContext>, ILabTestRepository
    {
        public LabTestRepository(LabDbContext context) : base(context) {}


        public override async Task<LabTest>  GetByIdAsync(int id)
        {
            return await Context.LabTests
                .Include(x => x.ReferenceRanges)
                .Include(x=> x.Conversions).SingleAsync(x => x.Id == id); 
        }

        public void RemoveConversion(LabTestConversion model)
        {
            Context.LabTestConversions.Remove(model);
        }

        public void RemoveReferenceRange(LabTestRefRange model)
        {
            Context.LabTestRefRanges.Remove(model);
        }

        public async Task<List<LabTest>> GetAllAsync()
        {
            return await Context.LabTests
                .Include(x => x.ReferenceRanges)
                .Include(x => x.Conversions).ToListAsync();
        }
    }
}
