namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConfigParam")]
    public class ConfigParam
    {
        [Key]
        public int ConfigParamsID { get; set; }

        [Required]
        [StringLength(50)]
        public string ParamName { get; set; }

        public int? ParamNumValue { get; set; }

        [StringLength(200)]
        public string ParamDesc { get; set; }
    }
}
