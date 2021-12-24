using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cmsWebApi.models.Domain.entities
{
    public class Grades
    {
        [Key]
        public int Id { get; set; }
        public int StudentId {get;set;}
        public virtual Student Student {get;set;}
        public int SubjectsId { get; set; }
        public virtual Subjects Subjects {get;set;}
        public decimal Grade { get; set; }
    }
}