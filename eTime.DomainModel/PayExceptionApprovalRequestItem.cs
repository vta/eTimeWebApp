namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayExceptionApprovalRequestItem")]
    public class PayExceptionApprovalRequestItem
    {
        public int PayExceptionApprovalRequestItemID { get; set; }

        public int PayExceptionApprovalRequestID { get; set; }

        [StringLength(50)]
        public string PayCode { get; set; }

        [StringLength(50)]
        public string PayCodeGroup { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public bool? AllDay { get; set; }

        [StringLength(50)]
        public string StartHours { get; set; }

        [StringLength(50)]
        public string EndHours { get; set; }

        [StringLength(50)]
        public string Usage { get; set; }

        [StringLength(2000)]
        public string Notes { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(5)]
        public string StartPeriod { get; set; }

        [StringLength(5)]
        public string EndPeriod { get; set; }

        [StringLength(50)]
        public string MealTime { get; set; }

        [StringLength(50)]
        public string TotalTime { get; set; }

        public DateTime? StatusDate { get; set; }

        public virtual PayExceptionApprovalRequest PayExceptionApprovalRequest { get; set; }
    }
}
