using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Knewin.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> : IDisposable where T : class
        {
            Task<T> Add(T obj);
            Task<T> GetById(int id);
            Task<IEnumerable<T>> GetAll();
            Task Update(T obj);
            Task Remove(T obj);
        }
}
