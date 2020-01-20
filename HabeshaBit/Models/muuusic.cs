namespace HabeshaBit.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Music")]
    public partial class Musuic
    {
        [Key]
        public int musiID { get; set; }

        [StringLength(50)]
        public string musicName { get; set; }

        public string musicPath { get; set; }

        public int? album { get; set; }

        [StringLength(128)]
        public string artist { get; set; }

        public string picPath { get; set; }
    }
}
