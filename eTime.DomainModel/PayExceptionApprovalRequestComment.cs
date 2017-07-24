namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayExceptionApprovalRequestComment")]
    public class PayExceptionApprovalRequestComment
    {
        [Key]
        public int PEARCommentID { get; set; }

        public int PayExceptionApprovaRequestID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }

        [StringLength(200)]
        public string CommentBy { get; set; }

        public DateTime? CommentDate { get; set; }

        [StringLength(100)]
        public string Step { get; set; }

        [StringLength(50)]
        public string RequestType { get; set; }
    }
}
