using System.Threading.Tasks;

namespace Lab.UI.Data.Repository
{
    public interface IGenericRespository<TEntity> where TEntity : class
    {
        void Add(TEntity model);
        Task<TEntity> GetByIdAsync(int id);
        bool HasChanges();
        void Remove(TEntity model);
        Task SaveAsync();
    }
}