namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeSheetApprovalRequestItemSAP")]
    public class TimeSheetApprovalRequestItemSAP
    {
        [Key]
        public int TSARItemSAPID { get; set; }

        public int TimeSheetApprovalRequestID { get; set; }

        public int TimeSheetApprovalRequestItemID { get; set; }

        public int EmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string PayCode { get; set; }

        [StringLength(50)]
        public string WBS { get; set; }

        [StringLength(50)]
        public string InternalOrder { get; set; }

        [StringLength(50)]
        public string CostCenter { get; set; }

        public decimal? Hours { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        [StringLength(10)]
        public string Action { get; set; }

        [StringLength(20)]
        public string ActivityType { get; set; }
    }
}
