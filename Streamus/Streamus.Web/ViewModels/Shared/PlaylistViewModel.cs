﻿namespace Streamus.Web.ViewModels.Shared
{
	using Streamus.Data.Models;
	using Streamus.Web.Infrastructure.Mapping;
	using Streamus.Web.ViewModels.Shared;
	using System.ComponentModel.DataAnnotations;

	public class PlaylistViewModel : BaseViewModel, IMapFrom<Playlist>
	{
		[Required]
		[UIHint("String")]
		public string Name { get; set; }
	}
}