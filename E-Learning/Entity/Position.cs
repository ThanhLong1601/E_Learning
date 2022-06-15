using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Entity
{
    [Table("Position")]
    public class Position
    {

        public Position()
        {
            Admins = new HashSet<Admin>();
        }

        public int positionId { get; set; }

        [StringLength(30)]
        public string positionName { get; set; }

        public bool? Status { get; set; }


        public ICollection<Admin> Admins { get; set; }
    }
}
