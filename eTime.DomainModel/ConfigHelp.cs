namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConfigHelp")]
    public class ConfigHelp
    {
        [Key]
        public int HelpID { get; set; }

        [StringLength(200)]
        public string HelpText { get; set; }

        [StringLength(200)]
        public string HelpLinkURL { get; set; }
    }
}
