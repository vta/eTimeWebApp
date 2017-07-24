namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FMLAComment")]
    public partial class FMLAComment
    {
        public int FMLACommentID { get; set; }

        public int FMLAID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }

        [StringLength(200)]
        public string CommentBy { get; set; }

        public DateTime? CommentDate { get; set; }

        [StringLength(50)]
        public string RequestType { get; set; }
    }
}
