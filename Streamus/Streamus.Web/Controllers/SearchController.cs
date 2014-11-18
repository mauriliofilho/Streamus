namespace Streamus.Web.Controllers
{
	using Streamus.Data;
	using Streamus.Web.Infrastructure.Services.Contracts;
	using Streamus.Web.ViewModels.Search;
	using System.Linq;
	using System.Web.Mvc;

	public class SearchController : BaseController
	{
		private ISearchServices services;

		public SearchController(IStreamusData data, ISearchServices services)
			: base(data)
		{
			this.services = services;
		}

		[HttpGet]
		public ActionResult Index(string query = "", int page = 0)
		{
			var model = new SearchIndexViewModel()
			{
				Query = query,
				Page = page
			};

			return View(model);
		}

		[HttpGet]
		[OutputCache(Duration = 1, VaryByParam = "query, page")]
		public ActionResult Search(string query = "", int page = 0)
		{
			const int pageSize = 4;

			var data = this.services.Search(query);
			var pagesCount = (data.Count() / pageSize);

			var items = data
				.Skip(page * pageSize)
				.Take(pageSize);

			var model = new SearchViewModel
			{
				CurrentPage = page,
				Items = items,
				PagesCount = pagesCount
			};

			return PartialView("_PageableSearchResult", model);
		}
	}
}