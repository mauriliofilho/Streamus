namespace Streamus.Web.InputModels
{
	using Streamus.Web.ViewModels.Shared;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class AddToCollectionInputModel
	{
		public string NewCollectionName { get; set; }

		public string CollectionId { get; set; }

		public IEnumerable<CollectionViewModel> Collections { get; set; }

		public SelectListItem[] CollectionOptions
		{
			get
			{
				return new SelectList(this.Collections, "ID", "Name").ToArray();
			}
		}
	}
}