namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FMLADesignationNotice")]
    public partial class FMLADesignationNotice
    {
        [Key]
        public int FMLADesignationID { get; set; }

        public int? FMLAID { get; set; }

        public bool? Approved { get; set; }

        public bool? NoDeviationLeave { get; set; }

        public bool? UnscheduledLeave { get; set; }

        public bool? UsePaidSickVacation { get; set; }

        public bool? SubstituteOrUsePaidLeave { get; set; }

        public bool? RequireFitnessCert { get; set; }

        public bool? EssentialFunctionsListAttached { get; set; }

        public bool? CertNotSufficient { get; set; }

        public bool? ExerciseRightOtherOpinion { get; set; }

        public bool? FMLACFRALeaveNotApproved { get; set; }

        public bool? FMLACFRALeaveNotApply { get; set; }

        public bool? FMLACFRALeaveEntitlementExhauseted { get; set; }

        public virtual FMLARequest FMLARequest { get; set; }
    }
}
