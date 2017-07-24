namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayExceptionFMLARequest")]
    public class PayExceptionFMLARequest
    {
        [Key]
        public int PEARFMLAID { get; set; }

        public int? PEARFMLAProcID { get; set; }

        public int? EmployeeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [StringLength(200)]
        public string EmployeePersonalEmail { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        public DateTime? SubmittedDate { get; set; }

        [StringLength(50)]
        public string SubmittedByUserID { get; set; }

        public DateTime? SupervisorApprovalDateTime { get; set; }

        [StringLength(50)]
        public string SupervisorApproverUserID { get; set; }

        public DateTime? RiskManagementApprovalDateTime { get; set; }

        [StringLength(50)]
        public string RiskManagementApprovalUserID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int? PDFID { get; set; }

        public bool? VTAFamilyForm { get; set; }

        public bool? OtherForm { get; set; }
    }
}
