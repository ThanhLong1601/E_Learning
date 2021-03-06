using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Entity
{
    public class Learning_Result
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string Student { get; set; }

        public int? Semester { get; set; }

        public int? Student_Test { get; set; }

        public bool? Status { get; set; }

        public Student Student1 { get; set; }

        public Student_Test Student_Test1 { get; set; }
    }
}
