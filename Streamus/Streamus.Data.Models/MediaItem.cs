namespace Streamus.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class MediaItem : BaseItem
	{
		public MediaItem()
			: base()
		{
			Collections = new HashSet<Collection>();
			Playlists = new HashSet<Playlist>();
		}

		[Required]
		[StringLength(50)]
		public string VideoId { get; set; }

		[Required]
		[StringLength(250)]
		public string Title { get; set; }

		[Required]
		public long Duration { get; set; }

		[Required]
		public string LQImageUrl { get; set; }

		[Required]
		public string MQImageUrl { get; set; }

		[Required]
		public string HQImageUrl { get; set; }

		public virtual ICollection<Collection> Collections { get; set; }

		public virtual ICollection<Playlist> Playlists { get; set; }
	}
}