namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminTimeKeeperEmployeeReport")]
    public class AdminTimeKeeperEmployeeReport
    {
        [Key]
        public int AdminTKEmplReportID { get; set; }

        [StringLength(100)]
        public string EmployeeName { get; set; }

        public int? EmployeeID { get; set; }

        [StringLength(50)]
        public string EmployeeUserID { get; set; }

        [StringLength(50)]
        public string TimeKeeperName { get; set; }

        [StringLength(50)]
        public string TimeKeeperUserID { get; set; }

        public int? TimeKeeperEmployeeID { get; set; }

        [StringLength(50)]
        public string TimeKeeperRole { get; set; }

        [StringLength(50)]
        public string SupervisorName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }

        public short? PrimaryLevel { get; set; }
    }
}
