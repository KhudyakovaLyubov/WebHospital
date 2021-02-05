namespace WebHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Timetable")]
    public partial class Timetable
    {
        [Key]
        public int IDTimetable { get; set; }

        public int Employee { get; set; }

        public DateTime? StartShift { get; set; }

        public DateTime? EndShift { get; set; }
    }
}
