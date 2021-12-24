using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsWebApi.models.Data.context;
using cmsWebApi.models.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace cmsWebApi.models.Data.repository
{
    public class SubjectsRepository : RepositoryBase<Subjects>, IRepositoryBase<Subjects>
    {
        public SubjectsRepository(cmsContext ctx) : base(ctx) { }
       
        public void Add(Subjects item)
        {
            base.Add(item);
        }

        public void Add(List<Subjects> item)
        {
            base.Add(item);
        }

        public Subjects AddGet(Subjects item)
        {
            return base.AddGet(item);
        }

        public Subjects Find(int id)
        {
            return base.Find(id);
        }

        public IQueryable<Subjects> List()
        {
            return _ctx.Subjects.Include("Courses").Include("Teacher");
        }
    }
}