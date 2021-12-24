using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsWebApi.models.Data.repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Find(int id);
        IQueryable<TEntity> List();
        void Add(TEntity item);
        void Add(List<TEntity> item);
        TEntity AddGet(TEntity item);
    }
}