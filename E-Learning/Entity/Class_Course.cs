using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Entity
{
    public class Class_Course
    {
        [Key]
        public int lassCourseId { get; set; }

        public DateTime? lession { get; set; }

        [StringLength(5)]
        public string Class { get; set; }

        public int? Course { get; set; }

        public bool? Status { get; set; }

        public Class Class1 { get; set; }

        public Course Course1 { get; set; }
    }
}
