namespace Streamus.Web.Areas.Administration.Controllers
{
	using Streamus.Data;
	using Model = Streamus.Data.Models.Collection;
	using ViewModel = Streamus.Web.ViewModels.Shared.CollectionViewModel;

	public class CollectionsController : BaseAdministrationController<Model, ViewModel>
	{
		protected override IRepository<Model> Items
		{
			get
			{
				return this.Data.Collections;
			}
		}

		public CollectionsController(IStreamusData data)
			: base(data)
		{
		}
	}
}