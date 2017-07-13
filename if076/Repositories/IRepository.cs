using System.Collections.Generic;
using System.Threading.Tasks;

namespace if076.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetList();
        Task<T> GetById(int id);
        Task<T> Create(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(int id);
    }
}
