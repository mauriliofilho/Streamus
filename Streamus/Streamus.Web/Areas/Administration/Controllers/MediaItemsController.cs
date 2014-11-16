namespace Streamus.Web.Areas.Administration.Controllers
{
	using Streamus.Data;
	using Model = Streamus.Data.Models.MediaItem;
	using ViewModel = Streamus.Web.Areas.Administration.ViewModel.MediaItemViewModel;

	public class MediaItemsController : BaseAdministrationController<Model, ViewModel>
	{
		protected override IRepository<Model> Items
		{
			get
			{
				return this.Data.MediaItems;
			}
		}

		public MediaItemsController(IStreamusData data)
			: base(data)
		{
		}
	}
}