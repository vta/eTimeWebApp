namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminTimeKeeperRole")]
    public class AdminTimeKeeperRole
    {
        [Key]
        public int TimeKeeperRoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string TimeKeeperRole { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int? Priority { get; set; }
    }
}
