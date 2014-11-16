using Streamus.Data;
using Streamus.Data.Models;
using Streamus.Web.Controllers;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Streamus.Web.Areas.UserData.Controllers
{
	public class PlaylistsController : BaseController
	{
		public PlaylistsController(IStreamusData data)
			: base(data)
		{
		}

		// GET: UserData/Playlists
		public ActionResult Index()
		{
			return View(Data.Playlists.All().ToList());
		}

		// GET: UserData/Playlists/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Playlist playlist = Data.Playlists.Find(id);
			if (playlist == null)
			{
				return HttpNotFound();
			}
			return View(playlist);
		}

		// GET: UserData/Playlists/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserData/Playlists/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name")] Playlist playlist)
		{
			if (ModelState.IsValid)
			{
				Data.Playlists.Add(playlist);
				Data.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(playlist);
		}

		// GET: UserData/Playlists/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Playlist playlist = Data.Playlists.Find(id);
			if (playlist == null)
			{
				return HttpNotFound();
			}
			return View(playlist);
		}

		// POST: UserData/Playlists/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name")] Playlist playlist)
		{
			if (ModelState.IsValid)
			{
				Data.Context.Entry(playlist).State = EntityState.Modified;
				Data.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(playlist);
		}

		// GET: UserData/Playlists/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Playlist playlist = Data.Playlists.Find(id);
			if (playlist == null)
			{
				return HttpNotFound();
			}
			return View(playlist);
		}

		// POST: UserData/Playlists/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{
			Playlist playlist = Data.Playlists.Find(id);
			Data.Playlists.Delete(playlist);
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