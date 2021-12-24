using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cmsWebApi.models.Domain.entities
{
    public class Subjects
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CoursesId { get; set; }
        public virtual Courses Courses { get; set; }        
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}