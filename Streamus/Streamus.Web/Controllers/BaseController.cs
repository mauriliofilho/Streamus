namespace Streamus.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Streamus.Data;
    using Streamus.Data.Models;

    using Microsoft.AspNet.Identity;

    [HandleError]
    public class BaseController : Controller
    {
		protected IStreamusData Data { get; private set; }

		protected User UserProfile { get; private set; }

		public BaseController(IStreamusData data)
		{
			this.Data = data;
		}

		protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
		{
			this.UserProfile = this.Data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

			return base.BeginExecute(requestContext, callback, state);
		}
    }
}