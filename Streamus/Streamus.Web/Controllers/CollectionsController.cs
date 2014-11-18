namespace Streamus.Web.Controllers
{
	using Streamus.Data;
	using System.Web.Mvc;

	public class CollectionsController : BaseController
	{
		public CollectionsController(IStreamusData data)
			: base(data)
		{
		}

		public ActionResult Add()
		{
			return PartialView("_Add");
		}
	}
}