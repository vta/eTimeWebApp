namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeSheetApprovalRequest")]
    public class TimeSheetApprovalRequest
    {
        public TimeSheetApprovalRequest()
        {
            TimeSheetApprovalRequestAttachment = new HashSet<TimeSheetApprovalRequestAttachment>();
            TimeSheetApprovalRequestComment = new HashSet<TimeSheetApprovalRequestComment>();
            TimeSheetApprovalRequestItem = new HashSet<TimeSheetApprovalRequestItem>();
        }

        public int TimeSheetApprovalRequestID { get; set; }

        public int? TSARProcID { get; set; }

        public int EmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [Column(TypeName = "image")]
        public byte[] StampedPDF { get; set; }

        public DateTime? SubmittedDate { get; set; }

        [StringLength(50)]
        public string SubmittedByUserID { get; set; }

        public DateTime? EmployeeReviewDateTime { get; set; }

        public DateTime? SupervisorApprovalDateTime { get; set; }

        [StringLength(50)]
        public string SupervisorApproverUserID { get; set; }

        public DateTime? RiskManagementApprovalDateTime { get; set; }

        [StringLength(50)]
        public string RiskManagementApprovalUserID { get; set; }

        public DateTime? HRApprovalDateTime { get; set; }

        [StringLength(50)]
        public string HRApprovalUserID { get; set; }

        public DateTime? PayRollApprovalDateTime { get; set; }

        [StringLength(50)]
        public string PayRollApprovalUserID { get; set; }

        public DateTime? TimeKeeperApprovalDateTime { get; set; }

        [StringLength(50)]
        public string TimeKeeperApprovalUserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day2 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day3 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day4 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day5 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day6 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day7 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day8 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day9 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day10 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day11 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day12 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day13 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Day14 { get; set; }

        public bool? WOOCApproval { get; set; }

        public bool? FMLAApproval { get; set; }

        public bool? LeadTrainingPayApproval { get; set; }

        public virtual ICollection<TimeSheetApprovalRequestAttachment> TimeSheetApprovalRequestAttachment { get; set; }

        public virtual ICollection<TimeSheetApprovalRequestComment> TimeSheetApprovalRequestComment { get; set; }

        public virtual ICollection<TimeSheetApprovalRequestItem> TimeSheetApprovalRequestItem { get; set; }
    }
}
