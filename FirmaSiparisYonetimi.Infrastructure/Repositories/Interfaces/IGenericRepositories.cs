using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Infrastructure.Repositories.Interfaces
{
    public interface IGenericRepositories<T> where T : class
    {

        Task<IEnumerable<T>> All();
        Task<T?> GetById(Guid id);
        Task<T> Add(T entity);
        Task<T?> Update(Guid id,T entity);
        Task<bool> Delete(Guid id);
    }
}
