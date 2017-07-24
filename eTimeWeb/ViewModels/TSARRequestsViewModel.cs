using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eTime.DomainModel;

namespace eTimeWeb.ViewModels
{
    public class TSARRequestsViewModel
        {

        public TSARRequestsViewModel()
            {

            }
        #region Properties

        public List<TSARRequestsReviewedByMe> TSARRequestsReviewedByMeList { get; set; }
        }

        public class TSARRequestsReviewedByMeModel
            {
            public int TSARID { get; set; }
            public string PayTypePeriod { get; set; }
            public DateTime? SubmittedDate { get; set; }
            public string EmpName { get; set; }
            public DateTime? SupervisorApprovalDateTime { get; set; }
            public string Status { get; set; }
            }

        #endregion

    
}