using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eTime.DomainModel;
using System.Web.Mvc;
using SAPSourceMasterApplication.DomainModel;

namespace eTimeWeb.ViewModels
{
    public class FMLAEmployeeViewModel
    {
        public FMLAEmployeeViewModel()
            {

            }
        #region Properties
        public FMLAEmployeeProfile FMLAEmployeeDetails { get; set; }
        public FMLARequest FMLARequestDetails { get; set; }
        public List<FMLAEmployeeForDD> FMLAEmployeeForDD { get; set; }
        public List<FMLAComment> FMLAComments { get; set; }
        public string Comment { get; set; }
        public SAPEmpQuotaBalance QuotaBalance { get; set; }
        public string EmpAgreementVerbiage { get; set; }
        
        #endregion
    }

    public class FMLADetailsViewModel
    {
        public int FMLAID { get; set; }
        public FMLARequest FMLARequestDetails { get; set; }

    }

    public class CommentsViewModel
    {
        public int FMLAID { get; set; }
        public int FMLACommentID { get; set; }
        public string Comment { get; set; }
        public string CommentBy { get; set; }
        public string CommentDate { get; set; }
    }
}