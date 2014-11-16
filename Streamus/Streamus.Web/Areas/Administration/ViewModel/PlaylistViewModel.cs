namespace Streamus.Web.Areas.Administration.ViewModel
{
	using Streamus.Data.Models;
	using Streamus.Web.Infrastructure.Mapping;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class PlaylistViewModel : BaseViewModel, IMapFrom<Playlist>
	{
		[Required]
		[UIHint("String")]
		public string Name { get; set; }
	}
}