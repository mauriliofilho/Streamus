namespace Streamus.Web.Areas.Administration.ViewModel
{
	using System.Web.Mvc;

	public class BaseViewModel
	{
		[HiddenInput(DisplayValue = false)]
		public string Id { get; set; }
	}
}