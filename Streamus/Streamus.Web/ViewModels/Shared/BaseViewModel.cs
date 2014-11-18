namespace Streamus.Web.ViewModels.Shared
{
	using System.Web.Mvc;

	public class BaseViewModel
	{
		[HiddenInput(DisplayValue = false)]
		public string Id { get; set; }
	}
}