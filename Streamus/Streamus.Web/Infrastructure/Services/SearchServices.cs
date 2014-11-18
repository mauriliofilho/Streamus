namespace Streamus.Web.Infrastructure.Services
{
	using AutoMapper.QueryableExtensions;
	using Google.GData.YouTube;
	using Google.YouTube;
	using Streamus.Data;
	using Streamus.Web.Infrastructure.Services.Base;
	using Streamus.Web.Infrastructure.Services.Contracts;
	using Streamus.Web.ViewModels.Shared;
	using System.Collections.Generic;
	using System.Linq;

	public class SearchServices : BaseServices, ISearchServices
	{
		public SearchServices(IStreamusData data)
			: base(data, true)
		{
		}

		public IEnumerable<MediaItemViewModel> Search(string query)
		{
			YouTubeQuery youtubeQuery = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);
			//order results by the number of views (most viewed first)
			youtubeQuery.OrderBy = "viewCount";

			// query.SafeSearch could also be set to YouTubeQuery.SafeSearchValues.Moderate
			youtubeQuery.Query = query;
			youtubeQuery.SafeSearch = YouTubeQuery.SafeSearchValues.None;

			return this.Request.Get<Video>(youtubeQuery)
				.Entries
				.AsQueryable()
				.Project()
				.To<MediaItemViewModel>();
		}
	}
}