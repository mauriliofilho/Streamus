namespace Streamus.Web.Infrastructure.Services.Base
{
	using Google.YouTube;
	using Streamus.Data;

	public abstract class BaseServices
	{
		protected IStreamusData Data { get; private set; }

		protected YouTubeRequestSettings Settings { get; set; }

		protected YouTubeRequest Request { get; set; }

		public BaseServices(IStreamusData data, bool hasYoutubeAccess = false)
		{
			this.Data = data;

			if (hasYoutubeAccess)
			{
				this.Settings = new YouTubeRequestSettings("MusicStreamer", "AI39si65eMHvaqUdhOESn1Z4xR9pSXPECS4BaQZ0GHA5sokyJY-QJGniwhQlccPwOMx8XBwgutGTC6keZToeFeURvcHFvVMGiw");
				this.Request = new YouTubeRequest(this.Settings);
			}
		}
	}
}