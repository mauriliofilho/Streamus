namespace Streamus.Web.Areas.Administration.Controllers
{
	using Streamus.Data;
	using Model = Streamus.Data.Models.User;
	using ViewModel = Streamus.Web.Areas.Administration.ViewModel.UserViewModel;

	public class UsersController : BaseAdministrationController<Model, ViewModel>
	{
		protected override IRepository<Model> Items
		{
			get
			{
				return this.Data.Users;
			}
		}

		public UsersController(IStreamusData data)
			: base(data)
		{
		}
	}
}