namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayExceptionLeadTrainingPayRequest")]
    public class PayExceptionLeadTrainingPayRequest
    {
        public PayExceptionLeadTrainingPayRequest()
        {
            PayExceptionLeadTrainingPayRequestWorkerItem = new HashSet<PayExceptionLeadTrainingPayRequestWorkerItem>();
        }

        [Key]
        public int PEARLeadID { get; set; }

        public int? PEARLeadProcID { get; set; }

        public int? EmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public bool? ConfirmInfoAccurate { get; set; }

        [StringLength(1000)]
        public string ProposedLeadTrainingNotes { get; set; }

        [StringLength(1000)]
        public string RelatedWorkNotes { get; set; }

        [StringLength(200)]
        public string RelatedWorkDurationNotes { get; set; }

        public DateTime? SubmittedDate { get; set; }

        [StringLength(50)]
        public string SubmittedByUserID { get; set; }

        public DateTime? SupervisorApprovalDateTime { get; set; }

        [StringLength(50)]
        public string SupervisorApproverUserID { get; set; }

        public DateTime? ChiefApprovalDateTime { get; set; }

        [StringLength(50)]
        public string ChiefApprovalUserID { get; set; }

        public DateTime? HRAnalystApprovalDateTime { get; set; }

        [StringLength(50)]
        public string HRAnalystApprovalUserID { get; set; }

        public DateTime? HRManagerApprovalDateTime { get; set; }

        [StringLength(50)]
        public string HRManagerApprovalUserID { get; set; }

        public DateTime? HRDirectorApprovalDateTime { get; set; }

        [StringLength(50)]
        public string HRDirectorApprovalUserID { get; set; }

        public DateTime? PayRollApprovalDateTime { get; set; }

        [StringLength(50)]
        public string PayRollApprovalUserID { get; set; }

        public int? PayExceptionApprovalRequestItemID { get; set; }

        public int? PDFID { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public bool? OrganizationChartForm { get; set; }

        public bool? OtherForm { get; set; }

        public virtual ICollection<PayExceptionLeadTrainingPayRequestWorkerItem> PayExceptionLeadTrainingPayRequestWorkerItem { get; set; }
    }
}
