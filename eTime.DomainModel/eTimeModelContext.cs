namespace eTime.DomainModel
    {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using log4net;
    using System.ComponentModel;

    public class eTimeModelContext : DbContext
        {

        private static readonly log4net.ILog LogManager = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public eTimeModelContext()
            : base("name=eTimeModelDbContextConnection")
            {
            }

        public DbSet<AbsenceReason> AbsenceReason { get; set; }
        public DbSet<AdminRole> AdminRole { get; set; }
        public DbSet<AdminTimeKeeperEmployeeReport> AdminTimeKeeperEmployeeReport { get; set; }
        public DbSet<AdminTimeKeeperList> AdminTimeKeeperList { get; set; }
        public DbSet<AdminTimeKeeperRole> AdminTimeKeeperRole { get; set; }
        public DbSet<AdminTimeKeeperRoleCostCenter> AdminTimeKeeperRoleCostCenter { get; set; }
        public DbSet<ConfigEscalations> ConfigEscalations { get; set; }
        public DbSet<ConfigExecRoleApprovers> ConfigExecRoleApprovers { get; set; }
        public DbSet<ConfigHours> ConfigHours { get; set; }
        public DbSet<ConfigMinutes> ConfigMinutes { get; set; }
        public DbSet<ConfigParam> ConfigParam { get; set; }
        public DbSet<PayExceptionApprovalRequest> PayExceptionApprovalRequest { get; set; }
        public DbSet<PayExceptionApprovalRequestAttachment> PayExceptionApprovalRequestAttachment { get; set; }
        public DbSet<PayExceptionApprovalRequestComment> PayExceptionApprovalRequestComment { get; set; }
        public DbSet<PayExceptionApprovalRequestItem> PayExceptionApprovalRequestItem { get; set; }
        public DbSet<PayExceptionFMLARequest> PayExceptionFMLARequest { get; set; }
        public DbSet<PayExceptionLeadTrainingPayRequest> PayExceptionLeadTrainingPayRequest { get; set; }
        public DbSet<PayExceptionLeadTrainingPayRequestWorkerItem> PayExceptionLeadTrainingPayRequestWorkerItem { get; set; }
        public DbSet<PayExceptionWOOCRequest> PayExceptionWOOCRequest { get; set; }
        public DbSet<TimeSheetApprovalRequest> TimeSheetApprovalRequest { get; set; }
        public DbSet<TimeSheetApprovalRequestAttachment> TimeSheetApprovalRequestAttachment { get; set; }
        public DbSet<TimeSheetApprovalRequestComment> TimeSheetApprovalRequestComment { get; set; }
        public DbSet<TimeSheetApprovalRequestHoldItem> TimeSheetApprovalRequestHoldItem { get; set; }
        public DbSet<TimeSheetApprovalRequestItem> TimeSheetApprovalRequestItem { get; set; }
        public DbSet<TimeSheetApprovalRequestItemHoldPEARRefresh> TimeSheetApprovalRequestItemHoldPEARRefresh { get; set; }
        public DbSet<TimeSheetApprovalRequestItemSAP> TimeSheetApprovalRequestItemSAP { get; set; }
        public DbSet<TSARServiceTracker> TSARServiceTracker { get; set; }
        public DbSet<TSARServiceTrackerArchive> TSARServiceTrackerArchive { get; set; }
        public DbSet<TSARWorkScheduleEmployee> TSARWorkScheduleEmployee { get; set; }
        public DbSet<ConfigHelp> ConfigHelp { get; set; }

        public DbSet<FMLAAttachment> FMLAAttachment { get; set; }
        public DbSet<FMLAComment> FMLAComment { get; set; }
        public DbSet<FMLADesignationNotice> FMLADesignationNotice { get; set; }
        public DbSet<FMLAIntermittentEpisodeFrequency> FMLAIntermittentEpisodeFrequency { get; set; }
        public DbSet<FMLANoticeofEligibilityRNR> FMLANoticeofEligibilityRNR { get; set; }
        public DbSet<FMLAProjections> FMLAProjections { get; set; }
        public DbSet<FMLARequest> FMLARequest { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            base.OnModelCreating(modelBuilder);
            }

        // NetSpecx Inc -- 09/08/2016 -- SM Gets Approved Requests Details
        public List<TSARRequestsReviewedByMe> GetReviewedByMeList()
            {
                try
                {
                using (var context = new eTimeModelContext())
                    {
                    List<TSARRequestsReviewedByMe> result = context.Database.SqlQuery<TSARRequestsReviewedByMe>("uspTSARApprovedRequestDetails").ToList<TSARRequestsReviewedByMe>();
                    return result;
                    }
                }
                catch
                {
                    return null;
                }
            }

        // NetSpecx Inc -- 09/12/2016 -- SM Gets TSAR Item Requests Details
        public List<TimeSheetApprovalRequestItem> GetTSARItemsList(int tsarID)
            {
            try
                {
                tsarID = 1;
                using (var context = new eTimeModelContext())
                    {
                    SqlParameter[] sp = new SqlParameter[]
                     {
                          new SqlParameter() {ParameterName = "@TimeSheetApprovalRequestID", SqlDbType = SqlDbType.Int, Value =  tsarID},
                         
                     };
                    List<TimeSheetApprovalRequestItem> result = context.Database.SqlQuery<TimeSheetApprovalRequestItem>("uspTSARGetItemsforWeb @TimeSheetApprovalRequestID", sp).ToList<TimeSheetApprovalRequestItem>();
                    return result;
                    }
                }
            catch
                {
                return null;
                }
            }

        public List<TimeSheetApprovalRequestItem> SaveTimeSheetApprovalRequestItem(List<TimeSheetApprovalRequestItem> tsarItems)
            {
            try
                {
                LogManager.Debug("SaveTimeSheetApprovalRequestItem: START");
                using (var context = new eTimeModelContext())
                    {
                    SqlParameter parameter = PrepareTSARItems(tsarItems);
                    var result = context.Database.SqlQuery<TimeSheetApprovalRequestItem>("uspTSARSaveWebItems @TSARItemsTabletype", parameter).ToList<TimeSheetApprovalRequestItem>();
                    LogManager.Debug("SaveTimeSheetApprovalRequestItem: END");
                    return result;
                    //return null;
                    }
                }
            catch (Exception ex)
                {
                LogManager.Error("SaveTimeSheetApprovalRequestItem: ERROR " + ex.Message, ex);
                return null;
                }
            }

        private SqlParameter PrepareTSARItems(List<TimeSheetApprovalRequestItem> tsarItems)
            {
            try
                {
                LogManager.Debug("PrepareTSARItems: START");
                string typeName = "dbo.TimeSheetApprovalRequestItemType";
                DataTable table = CreateDataTable(tsarItems);
                SqlParameter parameter = new SqlParameter("@TSARItemsTabletype", table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = typeName;
                LogManager.Debug("PrepareTSARItems: END");
                return parameter;
                }
            catch (Exception ex)
                {
                LogManager.Error("PrepareTSARItems: ERROR " + ex.Message, ex);
                return null;
                }
            }

        private static DataTable CreateDataTable(List<TimeSheetApprovalRequestItem> tsarItems)
            {
            try
                {
                LogManager.Debug("CreateDataTable: START");
                string configColumn = "StartDate";
                string configColumn2 = "SortOrder";
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(TimeSheetApprovalRequestItem));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (TimeSheetApprovalRequestItem profile in tsarItems)
                    {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(profile) ?? DBNull.Value;
                    table.Rows.Add(row);
                    }
                if (table.Columns.Contains(configColumn))
                    table.Columns.Remove(configColumn);
                if (table.Columns.Contains(configColumn2))
                    table.Columns.Remove(configColumn2);

                LogManager.Debug("CreateDataTable: END");
                return table;
                }

            catch (Exception ex)
                {
                LogManager.Error("CreateDataTable: ERROR " + ex.Message, ex);
                return null;
                }
            }

        public FMLAEmployeeProfile GetFMLAEmployeeProfile(int empID)
        {
            try
            {
                using (var context = new eTimeModelContext())
                {
                    var clientIdParameter = new SqlParameter("@empID", empID);
                    var result = context.Database.SqlQuery<FMLAEmployeeProfile>("uspFMLAWebGetHeaderData @empID", clientIdParameter).FirstOrDefault();
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<FMLAEmployeeForDD> GetEmployeesForDD(int empID)
        {
            try
            {
                using (var context = new eTimeModelContext())
                {
                    var clientIdParameter = new SqlParameter("@empID", empID);
                    var result = context.Database.SqlQuery<FMLAEmployeeForDD>("uspFMLAWebGetEmployeeListForDD @empID", clientIdParameter).ToList<FMLAEmployeeForDD>();
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }

        //public List<FMLAEmployeeForDD> GetFMLAEmployeeListForDD(int employeeID, string userID)
        //{
        //    try
        //    {
        //        using (var context = new eTimeModelContext())
        //        {
        //            SqlParameter[] sp = new SqlParameter[]
        //             {
        //                  new SqlParameter() {ParameterName = "@EmployeeID", SqlDbType = SqlDbType.Int, Value =  employeeID},
        //                  new SqlParameter() {ParameterName = "@UserID", SqlDbType = SqlDbType.VarChar, Value =  userID},
                         
        //             };
        //            List<FMLAEmployeeForDD> result = context.Database.SqlQuery<FMLAEmployeeForDD>("uspGetEmployeesFMLAForDropDown @EmployeeID,@UserID", sp).ToList<FMLAEmployeeForDD>();
        //            return result;
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public string GetEmpAgreementVerb(string paramName)
        {
            try
            {
                using (var context = new eTimeModelContext())
                {
                    var clientIdParameter = new SqlParameter("@ParamName", paramName);
                    var result = context.Database.SqlQuery<string>("uspFMLAWebGetEmpAgreementVerb @ParamName", clientIdParameter).FirstOrDefault();
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }

        public string CreateNewFMLARecord(string fmlaType, string email, string leaveStartDate, string leaveEndDate,
                bool mailNotif, string payStatus, int employeeID)
        {
            using (var context = new eTimeModelContext())
            {
                SqlParameter[] sp = new SqlParameter[]
                       {
                           new SqlParameter() {ParameterName = "@FMLAType", SqlDbType = SqlDbType.VarChar, Value= fmlaType},
                           new SqlParameter() {ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value =  email},
                           new SqlParameter() {ParameterName = "@startdate", SqlDbType = SqlDbType.VarChar, Value= leaveStartDate},
                           new SqlParameter() {ParameterName = "@enddate", SqlDbType = SqlDbType.VarChar, Value =  leaveEndDate},
                           new SqlParameter() {ParameterName = "@mailNotif", SqlDbType = SqlDbType.Bit, Value= mailNotif},
                           new SqlParameter() {ParameterName = "@payStatus", SqlDbType = SqlDbType.VarChar, Value =  payStatus},
                           new SqlParameter() {ParameterName = "@empID", SqlDbType = SqlDbType.Int, Value =  employeeID},
                       };
                var result = context.Database.SqlQuery<string>("uspFMLAWebCreateNewFMLA @fmlaType, @email, @startdate, @enddate, @mailNotif, @payStatus, @empID", sp).FirstOrDefault();
                return result;
            }
        }

        public int GetFMLAIDOnLastInsert()
        {
            using (var context = new eTimeModelContext())
            {
                var result = context.Database.SqlQuery<int>("uspFMLAWebGetFMLAIDOnLastInsert").FirstOrDefault();
                return result;
            }
        }

        public void SaveFMLAReasonCode(int FMLAID, string fmlaReason)
        {
            using (var context = new eTimeModelContext())
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FMLAID", SqlDbType = SqlDbType.Int, Value = FMLAID},
                    new SqlParameter() {ParameterName = "@FMLAReason", SqlDbType = SqlDbType.VarChar, Value =  fmlaReason},
                };
                var result = context.Database.SqlQuery<FMLARequest>("uspFMLAWebSaveFMLAReason @FMLAID,@FMLAReason", sp).FirstOrDefault();
            }
        }

        public void SaveFMLACareMemberName(int FMLAID, string memberName)
        {
            using (var context = new eTimeModelContext())
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FMLAID", SqlDbType = SqlDbType.Int, Value = FMLAID},
                    new SqlParameter() {ParameterName = "@MemberName", SqlDbType = SqlDbType.VarChar, Value =  memberName},
                };
                var result = context.Database.SqlQuery<FMLARequest>("uspFMLAWebSaveMemberNameForCare @FMLAID,@MemberName", sp).FirstOrDefault();
            }
        }

        public void SaveFMLACareMemberRelationship(int FMLAID, string relationship)
        {
            using (var context = new eTimeModelContext())
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FMLAID", SqlDbType = SqlDbType.Int, Value = FMLAID},
                    new SqlParameter() {ParameterName = "@Relationship", SqlDbType = SqlDbType.VarChar, Value =  relationship},
                };
                var result = context.Database.SqlQuery<FMLARequest>("uspFMLAWebSaveMemberRelationship @FMLAID,@Relationship", sp).FirstOrDefault();
            }
        }

        public void SaveFMLACareChildAge(int FMLAID, int childAge)
        {
            using (var context = new eTimeModelContext())
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FMLAID", SqlDbType = SqlDbType.Int, Value = FMLAID},
                    new SqlParameter() {ParameterName = "@ChildAge", SqlDbType = SqlDbType.Int, Value =  childAge},
                };
                var result = context.Database.SqlQuery<FMLARequest>("uspFMLAWebSaveMemberChildAge @FMLAID,@ChildAge", sp).FirstOrDefault();
            }
        }

        public void SaveFMLOtherMembrAvlablBit(int FMLAID, bool isOtherMembrAvlbl)
        {
            using (var context = new eTimeModelContext())
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter() {ParameterName = "@FMLAID", SqlDbType = SqlDbType.Int, Value= FMLAID},
                    new SqlParameter() {ParameterName = "@MemberBit", SqlDbType = SqlDbType.Bit, Value =  isOtherMembrAvlbl},
                };
                var result = context.Database.SqlQuery<FMLARequest>("uspFMLAWebSaveOtherMembrAvlablBit @FMLAID,@MemberBit", sp).FirstOrDefault();
            }
        }

        /// <summary>
        /// 8/25/2017 SM Gets UserID of the Employee if he is configured for RoleName
        /// </summary>
        /// <param name="roleabbreviation">Name of the Role</param>
        /// <param name="InvoiceMasterID">Pass NULL, if Role Name is a Admin role, else pass InvoiceMasterID for which to determine user Authentication </param>
        /// <returns>UserName if the user is valid for Role Name Passed </returns>
        public string VerifyUserAccess(string module, int processID, string userID)
            {
            try
                {
                string message = "";
                LogManager.Debug("VerifyUserAccess: START");
                using (var context = new eTimeModelContext())
                    {
                    //List<String> assignedUsers = new List<string>();
                    SqlParameter[] sp = new SqlParameter[]
               {
                   new SqlParameter() {ParameterName = "@Module", SqlDbType = SqlDbType.VarChar, Value =  module},
                   new SqlParameter() {ParameterName = "@ProcessID", SqlDbType = SqlDbType.Int,  Value = processID},
                   new SqlParameter() {ParameterName = "@userID", SqlDbType = SqlDbType.VarChar,  Value = userID},
               };

                    // var result = context.Database.SqlQuery<int>("uspWebVerifyAccess @Module, @ProcessID", sp).FirstOrDefault();

                    var result = context.Database.SqlQuery<VerifyUser>("uspWebVerifyAccess @Module, @ProcessID, @UserID", sp).ToList<VerifyUser>();
                    if (result.Count > 0)
                        {
                        foreach (VerifyUser role in result)
                            message = role.ValidationMessage;
                        //assignedUsers.Add(role.Approver);
                        }
                    return message;
                    }
                }
            catch (Exception ex)
                {
                LogManager.Error("VerifyUserAccess: ERROR " + ex.Message, ex);
                return null;
                }
            }
            
    }
}
