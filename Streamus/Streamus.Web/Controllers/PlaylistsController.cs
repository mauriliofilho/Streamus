namespace Streamus.Web.Controllers
{
	using Streamus.Data;
	using System.Web.Mvc;

	public class PlaylistsController : BaseController
	{
		public PlaylistsController(IStreamusData data)
			: base(data)
		{
		}

		public ActionResult Add()
		{
			return PartialView("_Add");
		}
	}
}