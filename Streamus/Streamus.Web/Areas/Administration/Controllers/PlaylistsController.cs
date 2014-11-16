namespace Streamus.Web.Areas.Administration.Controllers
{
	using Streamus.Data;
	using Model = Streamus.Data.Models.Playlist;
	using ViewModel = Streamus.Web.Areas.Administration.ViewModel.PlaylistViewModel;

	public class PlaylistsController : BaseAdministrationController<Model, ViewModel>
	{
		protected override IRepository<Model> Items
		{
			get
			{
				return this.Data.Playlists;
			}
		}

		public PlaylistsController(IStreamusData data)
			: base(data)
		{
		}
	}
}