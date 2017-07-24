namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayExceptionLeadTrainingPayRequestWorkerItem")]
    public class PayExceptionLeadTrainingPayRequestWorkerItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PEARLeadID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string EmployeeUserID { get; set; }

        [StringLength(250)]
        public string EmployeeName { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Status { get; set; }

        public virtual PayExceptionLeadTrainingPayRequest PayExceptionLeadTrainingPayRequest { get; set; }
    }
}
