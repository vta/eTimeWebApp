namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminTimeKeeperRoleCostCenter")]
    public class AdminTimeKeeperRoleCostCenter
    {
        [Key]
        public int AdminRoleCostCenterID { get; set; }

        public int TimeKeeperRoleID { get; set; }

        public int? CostCenterIDFrom { get; set; }

        public int? CostCenterIDTo { get; set; }
    }
}
