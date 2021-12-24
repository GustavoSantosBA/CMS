using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsWebApi.models.Data.context;
using cmsWebApi.models.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace cmsWebApi.models.Data.repository
{
    public class TeacherRepository : RepositoryBase<Teacher>, IRepositoryBase<Teacher>
    {
        public TeacherRepository(cmsContext ctx) : base(ctx) { }
        public void Add(Teacher item)
        {
            base.Add(item);
        }

        public void Add(List<Teacher> item)
        {
            base.Add(item);
        }

        public Teacher AddGet(Teacher item)
        {
            return base.AddGet(item);
        }

        public Teacher Find(int id)
        {
            return base.Find(id);
        }

        public IQueryable<Teacher> List()
        {
            return _ctx.Teacher;
        }           
        
    }
}