namespace Streamus.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class MediaItem : BaseItem
	{
		public MediaItem()
			: base()
		{
			Collections = new HashSet<Collection>();
			Playlists = new HashSet<Playlist>();
		}

		[Required]
		[StringLength(500)]
		public string Link { get; set; }

		[Required]
		[StringLength(250)]
		public string Name { get; set; }

		[Required]
		[StringLength(250)]
		public string Duration { get; set; }

		[Required]
		[ForeignKey("Thumbnail")]
		public string ThumbnailId { get; set; }

		[Required]
		public virtual MediaItemThumbnail Thumbnail { get; set; }

		public virtual ICollection<Collection> Collections { get; set; }

		public virtual ICollection<Playlist> Playlists { get; set; }
	}
}