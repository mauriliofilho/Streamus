namespace Streamus.Web.Infrastructure.Services.Contracts
{
	using Streamus.Web.ViewModels.Shared;
	using System.Collections.Generic;

	public interface ISearchServices
	{
		IEnumerable<MediaItemViewModel> Search(string query);
	}
}