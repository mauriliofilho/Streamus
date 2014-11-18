namespace Streamus.Web.InputModels
{
	using Streamus.Web.ViewModels.Shared;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class AddToPlaylistInputModel
	{
		public string NewPlaylistName { get; set; }

		public string PlaylistId { get; set; }

		public IEnumerable<PlaylistViewModel> Playlists { get; set; }

		public SelectListItem[] PlaylistOptions
		{
			get
			{
				return new SelectList(this.Playlists, "ID", "Name").ToArray();
			}
		}
	}
}