namespace Streamus.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MediaItemThumbnail : BaseItem
    {
		public MediaItemThumbnail()
			: base()
        {
            MediaItems = new HashSet<MediaItem>();
        }

        [Required]
        [MaxLength(4000)]
        public byte[] Data { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public virtual ICollection<MediaItem> MediaItems { get; set; }
    }
}
