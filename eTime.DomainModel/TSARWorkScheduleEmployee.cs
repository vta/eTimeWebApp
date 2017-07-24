namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TSARWorkScheduleEmployee")]
    public class TSARWorkScheduleEmployee
    {
        [Key]
        public int TSARWSID { get; set; }

        public int? EmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        public int? MoHrs1 { get; set; }

        public int? TuHrs1 { get; set; }

        public int? WeHrs1 { get; set; }

        public int? ThHrs1 { get; set; }

        public int? FrHrs1 { get; set; }

        public int? SaHrs1 { get; set; }

        public int? SuHrs1 { get; set; }

        public int? MoHrs2 { get; set; }

        public int? TuHrs2 { get; set; }

        public int? WeHrs2 { get; set; }

        public int? ThHrs2 { get; set; }

        public int? FrHrs2 { get; set; }

        public int? SaHrs2 { get; set; }

        public int? SuHrs2 { get; set; }
    }
}
