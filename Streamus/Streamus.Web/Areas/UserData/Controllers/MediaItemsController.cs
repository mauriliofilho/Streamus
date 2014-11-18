namespace Streamus.Web.Areas.UserData.Controllers
{
	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using Streamus.Data;
	using Streamus.Data.Models;
	using Streamus.Web.Controllers;
	using Streamus.Web.ViewModels.Shared;
	using System.Data.Entity;
	using System.Linq;
	using System.Net;
	using System.Web.Mvc;

	public class MediaItemsController : BaseController
	{
		public MediaItemsController(IStreamusData data)
			: base(data)
		{
		}

		// GET: UserData/MediaItems
		public ActionResult Index()
		{
			var items = this.Data.MediaItems.All().Project().To<MediaItemViewModel>().ToList();
			return View(items);
		}

		// GET: UserData/MediaItems/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			MediaItem mediaItem = this.Data.MediaItems.Find(id);
			if (mediaItem == null)
			{
				return HttpNotFound();
			}

			var model = Mapper.Map<MediaItemViewModel>(mediaItem);
			return View(model);
		}

		// GET: UserData/MediaItems/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserData/MediaItems/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "VideoId,Title,Duration,MQImageUrl,HQImageUrl")] MediaItem mediaItem)
		{
			if (ModelState.IsValid)
			{
				this.Data.MediaItems.Add(mediaItem);
				this.Data.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(mediaItem);
		}

		// GET: UserData/MediaItems/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			MediaItem mediaItem = this.Data.MediaItems.Find(id);
			if (mediaItem == null)
			{
				return HttpNotFound();
			}
			return View(mediaItem);
		}

		// POST: UserData/MediaItems/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,VideoId,Title,Duration,MQImageUrl,HQImageUrl")] MediaItem mediaItem)
		{
			if (ModelState.IsValid)
			{
				this.Data.Context.Entry(mediaItem).State = EntityState.Modified;
				this.Data.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(mediaItem);
		}

		// GET: UserData/MediaItems/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			MediaItem mediaItem = this.Data.MediaItems.Find(id);
			if (mediaItem == null)
			{
				return HttpNotFound();
			}
			return View(mediaItem);
		}

		// POST: UserData/MediaItems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{
			MediaItem mediaItem = this.Data.MediaItems.Find(id);
			this.Data.MediaItems.Delete(mediaItem);
			this.Data.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Data.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}