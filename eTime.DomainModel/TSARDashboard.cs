using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eTime.DomainModel
{
    public class TSARDashboard
    {      
        public int TSARID { get; set; }
        public string PayTypePeriod { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public string EmpName { get; set; }
        public DateTime? SupervisorApprovalDateTime { get; set; }
        public string Status { get; set; }
    }

    public class TSARRequestsReviewedByMe
        {   
    
        public int TimeSheetApprovalRequestID { get; set; }
        public string PayTypePeriod { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public string EmpName { get; set; }
        public DateTime? SupervisorApprovalDateTime { get; set; }
        public string Status { get; set; }
        }

}
