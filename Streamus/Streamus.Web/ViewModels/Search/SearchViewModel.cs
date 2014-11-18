using Streamus.Web.ViewModels.Shared;
using System.Collections.Generic;

namespace Streamus.Web.ViewModels.Search
{
	public class SearchViewModel
	{
		public int CurrentPage { get; set; }

		public bool IsFirstPage
		{
			get
			{
				return this.CurrentPage == 0;
			}
		}

		public bool IsLastPage
		{
			get
			{
				return this.CurrentPage == PagesCount - 1;
			}
		}

		public int PagesCount { get; set; }

		public IEnumerable<MediaItemViewModel> Items { get; set; }
	}
}