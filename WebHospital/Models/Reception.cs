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

        public int Employee { get; set; }

        public int Patient { get; set; }

        public DateTime? LogInDate { get; set; }

        public DateTime? LogInTime { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual Patient Patient1 { get; set; }
    }
}
