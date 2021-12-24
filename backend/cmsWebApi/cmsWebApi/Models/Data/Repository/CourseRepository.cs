using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsWebApi.models.Data.context;
using cmsWebApi.models.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace cmsWebApi.models.Data.repository
{
    public class CourseRepository : RepositoryBase<Courses>, IRepositoryBase<Courses>
    {
        public CourseRepository(cmsContext ctx) : base(ctx) { }

        public void Add(Courses item)
        {
            base.Add(item);
        }

        public void Add(List<Courses> item)
        {
            base.Add(item);
        }

        public Courses AddGet(Courses item)
        {
            return base.AddGet(item);
        }

        public Courses Find(int id)
        {
            return base.Find(id);
        }

        public IQueryable<Courses> List()
        {
            return _ctx.Courses;
        }
    }
}