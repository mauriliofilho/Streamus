namespace Streamus.Web.Infrastructure.Services
{
	using Google.GData.Client;
	using Google.GData.YouTube;
	using Google.YouTube;
	using Streamus.Data;
	using Streamus.Web.Infrastructure.Services.Base;
	using Streamus.Web.Infrastructure.Services.Contracts;

	public class HomeServices : BaseServices, IHomeServices
	{
		public HomeServices(IStreamusData data)
			: base(data, true)
		{
		}

		public Feed<Video> GetIndexViewModel()
		{
			return this.Request.GetStandardFeed(YouTubeQuery.MostPopular);
		}
	}
}