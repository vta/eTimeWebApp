namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeSheetApprovalRequestComment")]
    public class TimeSheetApprovalRequestComment
    {
        [Key]
        public int TSARCommentID { get; set; }

        public int TimeSheetApprovalRequestID { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        [StringLength(50)]
        public string CommentBy { get; set; }

        public DateTime? CommentDate { get; set; }

        public virtual TimeSheetApprovalRequest TimeSheetApprovalRequest { get; set; }
    }
}
