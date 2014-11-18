namespace Streamus.Web.ViewModels.Shared
{
	using Streamus.Data.Models;
	using Streamus.Web.Infrastructure.Mapping;
	using System.ComponentModel.DataAnnotations;

	public class CollectionViewModel : BaseViewModel, IMapFrom<Collection>
	{
		[Required]
		[UIHint("String")]
		public string Name { get; set; }
	}
}