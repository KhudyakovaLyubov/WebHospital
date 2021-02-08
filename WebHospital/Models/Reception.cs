namespace WebHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reception")]
    public partial class Reception
    {
        [Key]
        public int IDReception { get; set; }

        public int Employee { get; set; }

        public int Patient { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LogInDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LogInTime { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual Patient Patient1 { get; set; }
    }
}
