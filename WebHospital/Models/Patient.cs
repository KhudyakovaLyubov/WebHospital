namespace WebHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Reception = new HashSet<Reception>();
        }

        [Key]
        public int IDPatient { get; set; }

        [Required(ErrorMessage = "¬ведите ‘»ќ пациента")]
        [StringLength(50)]
        public string FIOPatient { get; set; }

        [Required(ErrorMessage = "¬ведите номер полиса")]
        public int? Policy { get; set; }

        [Required(ErrorMessage = "”кажите дату рождени€")]
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "¬ведите адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "¬ведите номер карты")]
        public int? CardNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reception> Reception { get; set; }
    }
}
