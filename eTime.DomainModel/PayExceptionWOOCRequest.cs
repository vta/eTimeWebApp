namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayExceptionWOOCRequest")]
    public class PayExceptionWOOCRequest
    {
        [Key]
        public int PEARWOOCID { get; set; }

        public int? PEARWOOCProcID { get; set; }

        public int? PayExceptionApprovalRequestItemID { get; set; }

        public int? EmployeeID { get; set; }

        public int? AbsentEmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "xml")]
        public string AbsenceReason { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? SupervisorApprovalDateTime { get; set; }

        [StringLength(50)]
        public string SupervisorApproverUserID { get; set; }

        public DateTime? ChiefApprovalDateTime { get; set; }

        [StringLength(50)]
        public string ChiefApprovalUserID { get; set; }

        public DateTime? HRApprovalDateTime { get; set; }

        [StringLength(50)]
        public string HRApprovalUserID { get; set; }

        public DateTime? PayRollApprovalDateTime { get; set; }

        [StringLength(50)]
        public string PayRollApprovalUserID { get; set; }

        public DateTime? SubmittedDate { get; set; }

        [StringLength(50)]
        public string SubmittedByUserID { get; set; }

        public int? PDFID { get; set; }

        public bool? WOOCPayrollForm { get; set; }

        public bool? VTAForm { get; set; }
    }
}
