using System;
using System.Web.Mvc;

namespace Streamus.Web.Infrastructure.HtmlHelpers
{
	public static class FormatHelpers
	{
		public static string FormatPeriodFromSeconds(this HtmlHelper helper, long seconds)
		{
			TimeSpan time = TimeSpan.FromSeconds(seconds);

			return string.Format(
				"{0:D2} hour {1:D2} min {2:D2} sec",
				time.Hours,
				time.Minutes,
				time.Seconds);
		}
	}
}