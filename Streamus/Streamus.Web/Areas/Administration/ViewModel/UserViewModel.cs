namespace Streamus.Web.Areas.Administration.ViewModel
{
	using Streamus.Data.Models;
	using Streamus.Web.Infrastructure.Mapping;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class UserViewModel : BaseViewModel, IMapFrom<User>
	{
		[Required]
		[UIHint("String")]
		public string UserName { get; set; }

		[Required]
		[UIHint("String")]
		public string Email { get; set; }
	}
}