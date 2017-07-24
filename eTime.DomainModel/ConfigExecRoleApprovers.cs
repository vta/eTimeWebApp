namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class ConfigExecRoleApprovers
    {
        [Key]
        public int ConfigExecRoleApproverID { get; set; }

        public int? ExecRolePosition { get; set; }

        [StringLength(100)]
        public string ExecRolePositionDesc { get; set; }

        public int? SupervisorRolePosition { get; set; }

        [StringLength(100)]
        public string SupervisorRolePositionDesc { get; set; }
    }
}
