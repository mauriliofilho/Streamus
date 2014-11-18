namespace Streamus.Web.Controllers
{
	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using Kendo.Mvc.Extensions;
	using Kendo.Mvc.UI;
	using Streamus.Data;
	using Streamus.Data.Models;
	using Streamus.Web.Infrastructure.Services.Contracts;
	using Streamus.Web.ViewModels.Shared;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	public class MediaItemsController : BaseController
	{
		private ISearchServices services;

		public MediaItemsController(IStreamusData data, ISearchServices services)
			: base(data)
		{
			this.services = services;
		}

		[HttpPost]
		public ActionResult Add(string videoId)
		{
			var video = this.Data.MediaItems.All().SingleOrDefault(item => item.VideoId == videoId);
			if (video != null)
			{
				return Content("OK:The video was already added!");
			}

			var viewModel = this.services.Get(videoId);
			var dbModel = Mapper.Map<MediaItem>(viewModel);
			dbModel.Id = Guid.NewGuid().ToString();

			this.Data.MediaItems.Add(dbModel);

			try
			{
				this.Data.SaveChanges();

				return Content("OK:The video was added successfully!");
			}
			catch (Exception ex)
			{
				return Content("ERROR:" + ex.Message);
			}
		}

		[ChildActionOnly]
		public ActionResult List()
		{
			return PartialView("_MediaItemsList", this.GetData());
		}

		public ActionResult Read([DataSourceRequest] DataSourceRequest request)
		{
			return Json(this.GetData().ToDataSourceResult(request));
		}

		private IEnumerable<MediaItemViewModel> GetData()
		{
			return this.Data.MediaItems.All().Project().To<MediaItemViewModel>();
		}
	}
}