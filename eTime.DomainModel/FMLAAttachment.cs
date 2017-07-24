namespace eTime.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FMLAAttachment")]
    public partial class FMLAAttachment
    {
        public int FMLAAttachmentID { get; set; }

        public int FMLAID { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        public string FileAttachment { get; set; }
    }
}
