namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("TimeSheetApprovalRequestItem")]
    public class TimeSheetApprovalRequestItem
    {
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

        public decimal? D1 { get; set; }

        public decimal? D2 { get; set; }

        public decimal? D3 { get; set; }

        public decimal? D4 { get; set; }

        public decimal? D5 { get; set; }

        public decimal? D6 { get; set; }

        public decimal? D7 { get; set; }

        public decimal? D8 { get; set; }

        public decimal? D9 { get; set; }

        public decimal? D10 { get; set; }

        public decimal? D11 { get; set; }

        public decimal? D12 { get; set; }

        public decimal? D13 { get; set; }

        public decimal? D14 { get; set; }


        public decimal? Total { get; set; }

        public int? SortOrder { get; set; }

        public DateTime StartDate { get; set; }

        //public virtual TimeSheetApprovalRequest TimeSheetApprovalRequest { get; set; }
    }
}
