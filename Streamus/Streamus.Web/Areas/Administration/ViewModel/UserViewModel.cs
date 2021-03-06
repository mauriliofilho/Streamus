﻿namespace Streamus.Web.Areas.Administration.ViewModel
{
	using Streamus.Data.Models;
	using Streamus.Web.Infrastructure.Mapping;
	using Streamus.Web.ViewModels.Shared;
	using System.ComponentModel.DataAnnotations;

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