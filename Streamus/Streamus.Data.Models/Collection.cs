namespace Streamus.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class Collection : BaseItem
	{
		public Collection()
			: base()
		{
			MediaItems = new HashSet<MediaItem>();
			Playlists = new HashSet<Playlist>();
		}

		[Required]
		[StringLength(250)]
		public string Name { get; set; }

		public virtual ICollection<MediaItem> MediaItems { get; set; }

		public virtual ICollection<Playlist> Playlists { get; set; }
	}
}