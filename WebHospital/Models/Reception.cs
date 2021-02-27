namespace WebHospital.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Reception")]
    public partial class Reception
    {
        [Key]
        public int IDReception { get; set; }

        [Required(ErrorMessage = "Выберите врача")]
        public int Employee { get; set; }

        [Required(ErrorMessage = "Выберите пациента")]
        public int Patient { get; set; }

        
        [Required(ErrorMessage = "Выберите дату")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? LogInDate { get; set; }

        [Required(ErrorMessage = "Выберите время")]
        public TimeSpan? LogInTime { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual Patient Patient1 { get; set; }
    }
}
