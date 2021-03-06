using System.Threading.Tasks;

namespace Lab.UI.ViewModel
{
    public interface IDetailViewModel
    {
        bool HasChanges { get; }
        Task LoadAsync(int?id);
    }
}