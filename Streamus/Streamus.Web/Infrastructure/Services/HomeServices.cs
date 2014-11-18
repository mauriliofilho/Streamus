namespace Streamus.Web.Infrastructure.Services
{
	using System.Linq;
	using System.Collections.Generic;

	using AutoMapper.QueryableExtensions;
	using Google.GData.Client;
	using Google.GData.YouTube;

	using Streamus.Data;
	using Streamus.Web.Infrastructure.Services.Base;
	using Streamus.Web.Infrastructure.Services.Contracts;
	using Streamus.Web.ViewModels.Shared;

	public class HomeServices : BaseServices, IHomeServices
	{
		public HomeServices(IStreamusData data)
			: base(data, true)
		{
		}

		public IEnumerable<MediaItemViewModel> GetIndexViewModel()
		{
			return this.Request.GetStandardFeed(YouTubeQuery.MostPopular)
				.Entries
				.AsQueryable()
				.Project()
				.To<MediaItemViewModel>();
		}
	}
}