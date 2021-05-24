using Lab.Data;
using Lab.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.UI.Data.Lookups
{
    public class LookupDataService :  ILookupDataService
    {
        private Func<LabDbContext> _context;

        public LookupDataService(Func<LabDbContext> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LookupItem>> GetLabLookupAsync()
        {
            using (var c = _context())
            {
                return await c.LabTests.AsNoTracking()
                    .Select(x => new LookupItem { Id = x.Id, Display = x.TestName }).ToListAsync();
            }
        }

        public async Task<IEnumerable<LookupItem>> GetCdiscTestCodeLookupAsync()
        {
            using (var c = _context())
            {
                return await c.CdiscTestCds.AsNoTracking()
                    .Select(x => new LookupItem { Id = x.Id, Display = x.Name }).ToListAsync();
            }
        }

        public async Task<IEnumerable<LookupItem>> GetUnitsLookupAsync()
        {
            using (var c = _context())
            {
                return await c.Units.AsNoTracking()
                    .Select(x => new LookupItem { Id = x.Id, Display = x.Name }).ToListAsync();
            }
        }
    }
}
