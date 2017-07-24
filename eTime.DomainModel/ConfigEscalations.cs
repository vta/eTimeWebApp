namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class ConfigEscalations
    {
        public int ConfigEscalationsID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProcessName { get; set; }

        [Required]
        [StringLength(100)]
        public string ActivityName { get; set; }

        public int? FirstReminderDays { get; set; }

        public int? SecondReminderDays { get; set; }

        public int? ExpiresAfter { get; set; }
    }
}
