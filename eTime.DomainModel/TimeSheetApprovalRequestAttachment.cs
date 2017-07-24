namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeSheetApprovalRequestAttachment")]
    public class TimeSheetApprovalRequestAttachment
    {
        [Key]
        public int AttachmentID { get; set; }

        public int TimeSheetApprovalRequestID { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        public string FileAttachment { get; set; }

        public virtual TimeSheetApprovalRequest TimeSheetApprovalRequest { get; set; }
    }
}
