using Lab.UI.ModelWrapper;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab.UI.ViewModel
{
    public interface ILabTestDetailViewModel
    {
        bool HasChanges { get;  }
        Task LoadAsync(int? testId);
    }
}