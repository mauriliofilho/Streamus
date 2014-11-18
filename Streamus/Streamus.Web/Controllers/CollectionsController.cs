namespace Streamus.Web.Controllers
{
	using AutoMapper.QueryableExtensions;
	using Kendo.Mvc.Extensions;
	using Kendo.Mvc.UI;
	using Streamus.Data;
	using Streamus.Web.InputModels;
	using Streamus.Web.ViewModels.Shared;
	using System.Collections.Generic;
	using System.Web.Mvc;

	public class CollectionsController : BaseController
	{
		public CollectionsController(IStreamusData data)
			: base(data)
		{
		}

		public ActionResult Add()
		{
			var model = new AddToCollectionInputModel()
			{
				Collections = this.Data.Collections.All()
					.Project()
					.To<CollectionViewModel>()
			};

			return PartialView("_Add", model);
		}

		[ChildActionOnly]
		public ActionResult List()
		{
			return PartialView("_CollectionsList", this.GetData());
		}

		public ActionResult Read([DataSourceRequest] DataSourceRequest request)
		{
			return Json(this.GetData().ToDataSourceResult(request));
		}

		private IEnumerable<CollectionViewModel> GetData()
		{
			return this.Data.Collections.All().Project().To<CollectionViewModel>();
		}
	}
}