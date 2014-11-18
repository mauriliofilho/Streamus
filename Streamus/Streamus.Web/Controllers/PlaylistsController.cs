namespace Streamus.Web.Controllers
{
	using AutoMapper.QueryableExtensions;
	using Kendo.Mvc.UI;
	using Kendo.Mvc.Extensions;
	using Streamus.Data;
	using Streamus.Web.InputModels;
	using Streamus.Web.ViewModels.Shared;
	using System.Collections.Generic;
	using System.Web.Mvc;

	public class PlaylistsController : BaseController
	{
		public PlaylistsController(IStreamusData data)
			: base(data)
		{
		}

		public ActionResult Add()
		{
			var model = new AddToPlaylistInputModel()
			{
				Playlists = this.Data.Playlists.All()
					.Project()
					.To<PlaylistViewModel>()
			};

			return PartialView("_Add", model);
		}

		[ChildActionOnly]
		public ActionResult List()
		{
			return PartialView("_PlaylistsList", this.GetData());
		}

		public ActionResult Read([DataSourceRequest] DataSourceRequest request)
		{
			return Json(this.GetData().ToDataSourceResult(request));
		}

		private IEnumerable<PlaylistViewModel> GetData()
		{
			return this.Data.Playlists.All().Project().To<PlaylistViewModel>();
		}
	}
}