namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminTimeKeeperList")]
    public class AdminTimeKeeperList
    {
        public int ID { get; set; }

        public int TimekeeperID { get; set; }

        [Required]
        [StringLength(50)]
        public string TimeKeeperUserID { get; set; }

        [Required]
        [StringLength(200)]
        public string TimeKeeperFullName { get; set; }

        public DateTime ExpirationDate { get; set; }

        [StringLength(200)]
        public string Notes { get; set; }
    }
}
