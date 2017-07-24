namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FMLAProjections
    {
        public int FMLAProjectionsID { get; set; }

        public int? FMLAID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [StringLength(10)]
        public string FMLACode { get; set; }

        public decimal? HoursPerDay { get; set; }

        public decimal? TotalHoursUtilized { get; set; }

        public decimal? HoursAvailable { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public virtual FMLARequest FMLARequest { get; set; }
    }
}
