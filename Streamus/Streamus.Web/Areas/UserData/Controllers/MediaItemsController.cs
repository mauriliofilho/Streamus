using Streamus.Data;
using Streamus.Data.Models;
using Streamus.Web.Controllers;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Streamus.Web.Areas.UserData.Controllers
{
	public class MediaItemsController : BaseController
	{
		public MediaItemsController(IStreamusData data)
			: base(data)
		{
		}

		// GET: UserData/MediaItems
		public ActionResult Index()
		{
			var mediaItems = this.Data.MediaItems.Include(m => m.Thumbnail);
			return View(mediaItems.ToList());
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
			return View(mediaItem);
		}

		// GET: UserData/MediaItems/Create
		public ActionResult Create()
		{
			ViewBag.ThumbnailId = new SelectList(this.Data.MediaItemThumbnails.All(), "Id", "Type");
			return View();
		}

		// POST: UserData/MediaItems/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Link,Name,Duration,ThumbnailId")] MediaItem mediaItem)
		{
			if (ModelState.IsValid)
			{
				Data.MediaItems.Add(mediaItem);
				Data.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.ThumbnailId = new SelectList(this.Data.MediaItemThumbnails.All(), "Id", "Type", mediaItem.ThumbnailId);
			return View(mediaItem);
		}

		// GET: UserData/MediaItems/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			MediaItem mediaItem = Data.MediaItems.Find(id);
			if (mediaItem == null)
			{
				return HttpNotFound();
			}
			ViewBag.ThumbnailId = new SelectList(this.Data.MediaItemThumbnails.All(), "Id", "Type", mediaItem.ThumbnailId);
			return View(mediaItem);
		}

		// POST: UserData/MediaItems/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Link,Name,Duration,ThumbnailId")] MediaItem mediaItem)
		{
			if (ModelState.IsValid)
			{
				this.Data.Context.Entry(mediaItem).State = EntityState.Modified;
				this.Data.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.ThumbnailId = new SelectList(this.Data.MediaItemThumbnails.All(), "Id", "Type", mediaItem.ThumbnailId);
			return View(mediaItem);
		}

		// GET: UserData/MediaItems/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			MediaItem mediaItem = Data.MediaItems.Find(id);
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
			MediaItem mediaItem = Data.MediaItems.Find(id);
			Data.MediaItems.Delete(mediaItem);
			Data.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Data.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}