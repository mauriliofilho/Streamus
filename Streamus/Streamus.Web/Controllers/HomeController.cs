using Streamus.Data;
using Streamus.Web.Infrastructure.Services.Contracts;
using System.Web.Mvc;

namespace Streamus.Web.Controllers
{
	public class HomeController : BaseController
	{
		private IHomeServices homeServices;

		public HomeController(IStreamusData data, IHomeServices homeServices)
			: base(data)
		{
			this.homeServices = homeServices;
		}

		public ActionResult Index()
		{
			return View();
		}

		[ChildActionOnly]
		[OutputCache(Duration = 1)]
		public ActionResult MostPopular()
		{
			return PartialView("_MediaItemsList", this.homeServices.GetIndexViewModel());
		}
	}
}