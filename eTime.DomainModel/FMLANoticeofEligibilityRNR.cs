namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FMLANoticeofEligibilityRNR")]
    public partial class FMLANoticeofEligibilityRNR
    {
        [Key]
        public int FMLARNRID { get; set; }

        public int? FMLAID { get; set; }

        public bool? ReasonBirthofChild { get; set; }

        public bool? ReasonOwnHealth { get; set; }

        [StringLength(50)]
        public string ReasonCareForOther { get; set; }

        [StringLength(50)]
        public string ReasonExigency { get; set; }

        [StringLength(50)]
        public string ReasonRelatedtoServiceMember { get; set; }

        public bool? Eligible { get; set; }

        public bool? NotMetFMLALengthofServiceReq { get; set; }

        public bool? NotMetFMLAHoursWorkedReq { get; set; }

        public bool? SufficientCert { get; set; }

        public bool? SupportCertFormEnclosed { get; set; }

        public bool? SufficientDocumentation { get; set; }

        public bool? OtherInformationNeeded { get; set; }

        public bool? NoAdditionalInfoRequested { get; set; }

        public bool? ContactVTABenefits { get; set; }

        [StringLength(50)]
        public string UseAvailablePaidRequired { get; set; }

        [StringLength(50)]
        public string KeyEmployee { get; set; }

        public bool? FurnishPeriodicStatusReport { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Single12MonthCommence { get; set; }

        [StringLength(50)]
        public string NotInformedUsePaid { get; set; }

        public virtual FMLARequest FMLARequest { get; set; }
    }
}
