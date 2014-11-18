namespace Streamus.Web.Controllers
{
	using AutoMapper.QueryableExtensions;
	using Streamus.Data;
	using Streamus.Web.InputModels;
	using Streamus.Web.ViewModels.Shared;
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
	}
}