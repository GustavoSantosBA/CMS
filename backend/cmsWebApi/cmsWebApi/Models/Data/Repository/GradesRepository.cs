using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsWebApi.models.Data.context;
using cmsWebApi.models.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace cmsWebApi.models.Data.repository
{
    public class GradesRepository : RepositoryBase<Grades>, IRepositoryBase<Grades>
    {
        public GradesRepository(cmsContext ctx) : base(ctx) { }
        
        public void Add(Grades item)
        {
            base.Add(item);
        }

        public void Add(List<Grades> item)
        {
            base.Add(item);
        }

        public Grades AddGet(Grades item)
        {
            return base.AddGet(item);
        }

        public Grades Find(int id)
        {
            return base.Find(id);
        }

        public IQueryable<Grades> List()
        {
            return _ctx.Grades.Include("Subjects").Include("Student");
        }
    }
}