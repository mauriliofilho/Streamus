namespace Streamus.Web.Areas.Administration.ViewModel
{
	using Streamus.Data.Models;
	using Streamus.Web.Infrastructure.Mapping;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public class MediaItemViewModel : BaseViewModel, IMapFrom<MediaItem>
	{
		[Required]
		[UIHint("String")]
		public string Name { get; set; }

		[Required]
		[UIHint("String")]
		public string Link { get; set; }

		[Required]
		[UIHint("String")]
		public string Duration { get; set; }

		[Required]
		[UIHint("String")]
		public string ThumbnailId { get; set; }
	}
}