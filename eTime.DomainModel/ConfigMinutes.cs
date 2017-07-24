namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class ConfigMinutes
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string MinutesDisplay { get; set; }

        [StringLength(10)]
        public string MinutesValue { get; set; }
    }
}
