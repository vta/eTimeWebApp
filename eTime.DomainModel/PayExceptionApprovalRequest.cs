namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayExceptionApprovalRequest")]
    public class PayExceptionApprovalRequest
    {
        public PayExceptionApprovalRequest()
        {
            PayExceptionApprovalRequestItem = new HashSet<PayExceptionApprovalRequestItem>();
        }

        public int PayExceptionApprovalRequestID { get; set; }

        public int? PEARProcID { get; set; }

        public int EmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public DateTime SubmittedDate { get; set; }

        [StringLength(50)]
        public string SubmittedByUserID { get; set; }

        public DateTime? SupervisorApprovalDateTime { get; set; }

        [StringLength(50)]
        public string SupervisorApproverUserID { get; set; }

        public DateTime? ChiefApprovalDateTime { get; set; }

        [StringLength(50)]
        public string ChiefApprovalUserID { get; set; }

        public DateTime? RiskManagementApprovalDateTime { get; set; }

        [StringLength(50)]
        public string RiskManagementApprovalUserID { get; set; }

        public DateTime? PayRollApprovalDateTime { get; set; }

        [StringLength(50)]
        public string PayRollApprovalUserID { get; set; }

        public DateTime? HRApprovalDateTime { get; set; }

        [StringLength(50)]
        public string HRApprovalUserID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [Column(TypeName = "image")]
        public byte[] StampedPDF { get; set; }

        public DateTime? StatusDate { get; set; }

        public virtual ICollection<PayExceptionApprovalRequestItem> PayExceptionApprovalRequestItem { get; set; }
    }
}
