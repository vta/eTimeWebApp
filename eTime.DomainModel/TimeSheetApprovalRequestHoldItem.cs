namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeSheetApprovalRequestHoldItem")]
    public class TimeSheetApprovalRequestHoldItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeSheetApprovalRequestItemID { get; set; }

        public int TimeSheetApprovalRequestID { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(50)]
        public string PayCode { get; set; }

        [StringLength(50)]
        public string WBS { get; set; }

        [StringLength(50)]
        public string InternalOrder { get; set; }

        [StringLength(50)]
        public string CostCenter { get; set; }

        public decimal? HoursDay1 { get; set; }

        public decimal? HoursDay2 { get; set; }

        public decimal? HoursDay3 { get; set; }

        public decimal? HoursDay4 { get; set; }

        public decimal? HoursDay5 { get; set; }

        public decimal? HoursDay6 { get; set; }

        public decimal? HoursDay7 { get; set; }

        public decimal? HoursDay8 { get; set; }

        public decimal? HoursDay9 { get; set; }

        public decimal? HoursDay10 { get; set; }

        public decimal? HoursDay11 { get; set; }

        public decimal? HoursDay12 { get; set; }

        public decimal? HoursDay13 { get; set; }

        public decimal? HoursDay14 { get; set; }

        [StringLength(50)]
        public string Action { get; set; }

        [StringLength(500)]
        public string CommentDay1 { get; set; }

        [StringLength(500)]
        public string CommentDay2 { get; set; }

        [StringLength(500)]
        public string CommentDay3 { get; set; }

        [StringLength(500)]
        public string CommentDay4 { get; set; }

        [StringLength(500)]
        public string CommentDay5 { get; set; }

        [StringLength(500)]
        public string CommentDay6 { get; set; }

        [StringLength(500)]
        public string CommentDay7 { get; set; }

        [StringLength(500)]
        public string CommentDay8 { get; set; }

        [StringLength(500)]
        public string CommentDay9 { get; set; }

        [StringLength(500)]
        public string CommentDay10 { get; set; }

        [StringLength(500)]
        public string CommentDay11 { get; set; }

        [StringLength(500)]
        public string CommentDay12 { get; set; }

        [StringLength(500)]
        public string CommentDay13 { get; set; }

        [StringLength(500)]
        public string CommentDay14 { get; set; }

        public decimal? Total { get; set; }

        public byte? SortOrder { get; set; }
    }
}
