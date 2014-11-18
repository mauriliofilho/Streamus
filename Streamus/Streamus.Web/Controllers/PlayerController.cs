namespace Streamus.Web.Controllers
{
	using Streamus.Data;
	using System.Web.Mvc;

	public class PlayerController : BaseController
	{
		public PlayerController(IStreamusData data)
			: base(data)
		{
		}

		public ActionResult Index()
		{
			return View();
		}
	}
}