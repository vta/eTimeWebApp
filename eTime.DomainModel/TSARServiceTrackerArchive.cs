namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TSARServiceTrackerArchive")]
    public class TSARServiceTrackerArchive
    {
        public int ID { get; set; }

        public int ServiceCounter { get; set; }

        public int? EmployeeID { get; set; }

        public int? Year { get; set; }

        public int? PayPeriod { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? DateTimeProcessed { get; set; }
    }
}
