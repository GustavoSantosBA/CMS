using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using cmsWebApi.models.Data.context;
using cmsWebApi.models.Domain.Extentions;
using Microsoft.EntityFrameworkCore;

namespace cmsWebApi.models.Data.repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly cmsContext _ctx;
        private string keyField { get; set; }
        public RepositoryBase(cmsContext ctx)
        {
            _ctx = ctx;
            SetFieldNames();
        }

        public void SetFieldNames(bool ignorePK = false)
        {
            var tableName = typeof(TEntity).GetCustomAttribute<TableAttribute>();
            string _tableName = tableName == null ? typeof(TEntity).Name : tableName.Name;
            //
            PropertyInfo[] properties = typeof(TEntity).GetProperties();
            foreach (var item in properties)
            {
                var key = item.GetCustomAttribute<KeyAttribute>();
                if (key != null) { keyField = item.Name; }
            }
        }

        public TEntity Find(int id)
        {
            return _ctx.Set<TEntity>().Find(id);
        }
        public IQueryable<TEntity> List(string comandoSQL)
        {
            return _ctx.Set<TEntity>().FromSqlRaw(comandoSQL).AsQueryable().AsNoTracking();
        }
        public IQueryable<TEntity> List()
        {
            return _ctx.Set<TEntity>();
        }

        public TEntity AddGet(TEntity item)
        {
            int Id = 0;
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                if (property.Name == keyField)
                {
                    Id = (property.GetValue(item, null)).ToInt();
                    break;
                }
            }
            if (Id > 0) { _ctx.Entry(item).State = EntityState.Modified; }
            else { _ctx.Set<TEntity>().Add(item); }
            _ctx.SaveChanges();
            return item;
        }
        public void Add(TEntity item)
        {
            int Id = 0;
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                if (property.Name == keyField)
                {
                    Id = (property.GetValue(item, null)).ToInt();
                    break;
                }
            }
            if (Id > 0) { _ctx.Entry(item).State = EntityState.Modified; }
            else { _ctx.Set<TEntity>().Add(item); }
            _ctx.SaveChanges();
        }
        public void Add(List<TEntity> item)
        {
            _ctx.Set<TEntity>().AddRange(item);
            _ctx.SaveChanges();
        }
        public void Remove(int id)
        {
            var item = _ctx.Set<TEntity>().Find(id);
            _ctx.Set<TEntity>().Remove(item);
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }

}