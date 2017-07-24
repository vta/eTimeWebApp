namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TSARServiceTracker")]
    public class TSARServiceTracker
    {
        [Key]
        public int ServiceCounter { get; set; }

        public int? EmployeeID { get; set; }

        public int? Year { get; set; }

        public int? PayPeriod { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? DateTimeProcessed { get; set; }
    }
}
