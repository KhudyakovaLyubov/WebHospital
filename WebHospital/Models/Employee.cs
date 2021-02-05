namespace WebHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Reception = new HashSet<Reception>();
        }

        [Key]
        public int IDEmpoyee { get; set; }

        [StringLength(50)]
        public string FIOEmployee { get; set; }

        public int Specialty { get; set; }

        public int? Cabinet { get; set; }

        public int? Part { get; set; }

        public virtual Specialty Specialty1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reception> Reception { get; set; }
    }
}
