using Lab.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab.UI.Data.Lookups
{
    public interface ILookupDataService
    {
        Task<IEnumerable<LookupItem>> GetCdiscTestCodeLookupAsync();
        Task<IEnumerable<LookupItem>> GetLabLookupAsync();
    }
}