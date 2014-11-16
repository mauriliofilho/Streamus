namespace Streamus.Web.Infrastructure.Services.Contracts
{
	using Google.GData.Client;
	using Google.YouTube;

	public interface IHomeServices
	{
		Feed<Video> GetIndexViewModel();
	}
}