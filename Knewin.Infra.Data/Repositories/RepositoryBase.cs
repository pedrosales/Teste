using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Knewin.Domain.Interfaces.Repositories;
using Knewin.Infra.Data.Context;

namespace Knewin.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected KnewinContext db;

        public RepositoryBase(KnewinContext context)
        {
            db = context;
        }

        async Task<T> IRepositoryBase<T>.Add(T obj)
        {
            var entity = db.Set<T>().Add(obj).Entity;

            await db.SaveChangesAsync();

            return entity;
        }

        async Task<T> IRepositoryBase<T>.GetById(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        async Task<IEnumerable<T>> IRepositoryBase<T>.GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        async Task IRepositoryBase<T>.Update(T obj)
        {
            db.Set<T>().Update(obj);
            await db.SaveChangesAsync();
        }

        async Task IRepositoryBase<T>.Remove(T obj)
        {
            db.Set<T>().Remove(obj);
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
