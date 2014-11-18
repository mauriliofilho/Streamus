namespace Streamus.Web.Controllers
{
	using Streamus.Data;
	using System.Web.Mvc;

	public class MediaItemsController : BaseController
	{
		public MediaItemsController(IStreamusData data)
			: base(data)
		{
		}

		public ActionResult Add()
		{
			return PartialView("_Add");
		}
	}
}