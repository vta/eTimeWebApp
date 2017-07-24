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
        }
    }