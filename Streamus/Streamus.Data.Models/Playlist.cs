namespace Streamus.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class Playlist : BaseItem
	{
		public Playlist()
			: base()
		{
			Collections = new HashSet<Collection>();
			MediaItems = new HashSet<MediaItem>();
		}

		[Required]
		[StringLength(250)]
		public string Name { get; set; }

		public virtual ICollection<Collection> Collections { get; set; }

		public virtual ICollection<MediaItem> MediaItems { get; set; }
	}
}