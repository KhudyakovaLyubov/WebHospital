namespace WebHospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        [Key]
        public int IDAddress { get; set; }

        [StringLength(50)]
        public string NameAddress { get; set; }

        public int Part { get; set; }

        public virtual Part Part1 { get; set; }
    }
}
