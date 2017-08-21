namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FMLARequest")]
    public partial class FMLARequest
    {
        public FMLARequest()
        {
            FMLAAttachment = new HashSet<FMLAAttachment>();
            FMLADesignationNotice = new HashSet<FMLADesignationNotice>();
            FMLAIntermittentEpisodeFrequency = new HashSet<FMLAIntermittentEpisodeFrequency>();
            FMLANoticeofEligibilityRNR = new HashSet<FMLANoticeofEligibilityRNR>();
            FMLAProjections = new HashSet<FMLAProjections>();
        }

        [Key]
        public int FMLAID { get; set; }

        public int? FMLAProcID { get; set; }

        public int? EmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string FMLAType { get; set; }

        [StringLength(50)]
        public string FMLAReason { get; set; }

        [StringLength(200)]
        public string FMLADescription { get; set; }

        [StringLength(200)]
        public string EmployeePersonalEmail { get; set; }

        public bool? PostalMailNotification { get; set; }

        [StringLength(50)]
        public string RequestedPayStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthPlacementDate { get; set; }

        [StringLength(100)]
        public string FamilyMemberName { get; set; }

        [StringLength(50)]
        public string FamilyMemberRelationship { get; set; }

        public int? ChildAge { get; set; }

        public bool? OtherFamilyAvailableforCare { get; set; }

        public bool? SpousePartnerEmployedbyVTA { get; set; }

        public bool? SpousePartnerRequestLeave { get; set; }

        public bool? EmpAcknowledgement { get; set; }

        public bool? EmpWorked12Months { get; set; }

        public bool? EmpWorked1250Hours { get; set; }

        public bool? VTAFamilyMedFormCertAttached { get; set; }

        public DateTime? SubmittedDate { get; set; }

        [StringLength(50)]
        public string SubmittedByUserID { get; set; }

        public DateTime? SupervisorApprovalDateTime { get; set; }

        [StringLength(50)]
        public string SupervisorApproverUserID { get; set; }

        public DateTime? FMLAApprovalDateTime { get; set; }

        [StringLength(50)]
        public string FMLAApprovalUserID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual ICollection<FMLAAttachment> FMLAAttachment { get; set; }

        public virtual ICollection<FMLADesignationNotice> FMLADesignationNotice { get; set; }

        public virtual ICollection<FMLAIntermittentEpisodeFrequency> FMLAIntermittentEpisodeFrequency { get; set; }

        public virtual ICollection<FMLANoticeofEligibilityRNR> FMLANoticeofEligibilityRNR { get; set; }

        public virtual ICollection<FMLAProjections> FMLAProjections { get; set; }
    }

    public class FMLAEmployeeProfile
    {
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public string SupervisorName { get; set; }

        public string Division { get; set; }

        public string CostCenterDesc { get; set; }

        public DateTime? SubmittedDate { get; set; }

        public string JobDescription { get; set; }

        public string Title { get; set; }

        public string Union { get; set; }

        public string Address { get; set; }

        public string WorkSchedule { get; set; }
    }

    public class FMLAEmployeeForDD
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }
}
