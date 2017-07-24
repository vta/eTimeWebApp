namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class ConfigHours
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string HoursDisplay { get; set; }

        [StringLength(10)]
        public string HoursValue { get; set; }
    }
}
