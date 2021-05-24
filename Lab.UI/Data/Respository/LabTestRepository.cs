using Lab.Data;
using Lab.Model;
using Microsoft.EntityFrameworkCore;
using System;
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
            return await Context.LabTests.Include(x => x.ReferenceRanges).SingleAsync(x => x.Id == id); 
        }

        public void RemoveReferenceRange(LabTestRefRange model)
        {
            Context.LabTestRefRanges.Remove(model);
        }

    }
}
