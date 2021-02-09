using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core
{
    public class Cities
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Departments Department { get; set; }
        public Nullable<Decimal> Latitude { get; set; }
        public Nullable<Decimal> Longitude { get; set; }
       
    }
}