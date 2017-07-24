using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eTime.DomainModel;

namespace eTimeWeb.ViewModels
    {
    public class TSARItemsViewModel
        {
        

    #region Properties

        public List<TimeSheetApprovalRequestItem> TSARItemsList { get; set; }
        }

        public class TSARItemsModel
            {
            public int TimeSheetApprovalRequestItemID { get; set; }
            public int TimeSheetApprovalRequestID { get; set; }
            public string Description { get; set; }
            public string PayCode { get; set; }
            public string WBS { get; set; }
            public string InternalOrder { get; set; }
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
            public decimal? Total { get; set; }
            public int? SortOrder { get; set; }
            public DateTime StartDate { get; set; }
            }

        #endregion
    }
