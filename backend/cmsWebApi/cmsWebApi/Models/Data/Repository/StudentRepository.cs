using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsWebApi.models.Data.context;
using cmsWebApi.models.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace cmsWebApi.models.Data.repository
{
    public class StudentRepository : RepositoryBase<Student>, IRepositoryBase<Student>
    {
        public StudentRepository(cmsContext ctx) : base(ctx) { }
       
        public void Add(Student item)
        {
            base.Add(item);
        }

        public void Add(List<Student> item)
        {
            base.Add(item);
        }

        public Student AddGet(Student item)
        {
            return base.AddGet(item);
        }

        public Student Find(int id)
        {
            return base.Find(id);
        }

        public IQueryable<Student> List()
        {
            return _ctx.Student;
        }
    }
}