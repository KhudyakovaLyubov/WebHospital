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

        [Required(ErrorMessage = "�������� �����")]
        public int Employee { get; set; }

        [Required(ErrorMessage = "�������� ��������")]
        public int Patient { get; set; }

        
        [Required(ErrorMessage = "�������� ����")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? LogInDate { get; set; }

        [Required(ErrorMessage = "�������� �����")]
        public TimeSpan? LogInTime { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual Patient Patient1 { get; set; }
    }
}
