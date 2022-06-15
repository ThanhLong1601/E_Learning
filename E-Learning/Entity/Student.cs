using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Entity
{
    [Table("Student")]
    public class Student
    {

        public Student()
        {
            Learning_Results = new HashSet<Learning_Result>();
            Student_Tests = new HashSet<Student_Test>();
            StudentAccounts = new HashSet<StudentAccount>();
        }

        [StringLength(10)]
        public string studentId { get; set; }

        [StringLength(10)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string lastName { get; set; }

        public bool? gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthDay { get; set; }

        [StringLength(5)]
        public string Class { get; set; }

        public bool? Status { get; set; }

        public Class Class1 { get; set; }


        public ICollection<Learning_Result> Learning_Results { get; set; }

        public ICollection<Student_Test> Student_Tests { get; set; }


        public ICollection<StudentAccount> StudentAccounts { get; set; }
    }
}
