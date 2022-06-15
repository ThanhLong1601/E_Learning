using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Entity
{
    [Table("TestCategory")]
    public class TestCategory
    {
        public TestCategory()
        {
            Tests = new HashSet<Test>();
        }

        [Key]
        public int testCateId { get; set; }

        [StringLength(50)]
        public string testCateName { get; set; }

        public bool? Status { get; set; }


        public ICollection<Test> Tests { get; set; }
    }
}
