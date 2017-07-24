namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FMLAIntermittentEpisodeFrequency")]
    public partial class FMLAIntermittentEpisodeFrequency
    {
        [Key]
        public int FMLAIntermittentID { get; set; }

        public int? FMLAID { get; set; }

        public int? EpisodeMax { get; set; }

        [StringLength(10)]
        public string EpisodeUnit { get; set; }

        public int? FrequecyMin { get; set; }

        public int? FrequencyMax { get; set; }

        [StringLength(10)]
        public string FrequencyUnit { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public decimal? WorkMaxHours { get; set; }

        [StringLength(10)]
        public string WorkUnit { get; set; }

        public virtual FMLARequest FMLARequest { get; set; }
    }
}
