using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Knewin.Application.Interfaces;
using Knewin.Domain.Interfaces.Repositories;

namespace Knewin.Application
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<T> Add(T obj)
        {
            return await _repositoryBase.Add(obj);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repositoryBase.GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repositoryBase.GetById(id);
        }

        public async Task Remove(T obj)
        {
            await _repositoryBase.Remove(obj);
        }

        public async Task Update(T obj)
        {
            await _repositoryBase.Update(obj);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
