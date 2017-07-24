namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayExceptionApprovalRequestAttachment")]
    public class PayExceptionApprovalRequestAttachment
    {
        [Key]
        public int AttachmentID { get; set; }

        public int PayExceptionApprovalRequestID { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        public string FileAttachment { get; set; }

        [StringLength(50)]
        public string RequestType { get; set; }
    }
}
