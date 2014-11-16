using Streamus.Data;
using Streamus.Data.Models;
using Streamus.Web.Controllers;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Streamus.Web.Areas.UserData.Controllers
{
	public class CollectionsController : BaseController
	{
		public CollectionsController(IStreamusData data)
			: base(data)
		{
		}

		// GET: UserData/Collections
		public ActionResult Index()
		{
			return View(Data.Collections.All().ToList());
		}

		// GET: UserData/Collections/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Collection collection = Data.Collections.Find(id);
			if (collection == null)
			{
				return HttpNotFound();
			}
			return View(collection);
		}

		// GET: UserData/Collections/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserData/Collections/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name")] Collection collection)
		{
			if (ModelState.IsValid)
			{
				Data.Collections.Add(collection);
				Data.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(collection);
		}

		// GET: UserData/Collections/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Collection collection = Data.Collections.Find(id);
			if (collection == null)
			{
				return HttpNotFound();
			}
			return View(collection);
		}

		// POST: UserData/Collections/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name")] Collection collection)
		{
			if (ModelState.IsValid)
			{
				Data.Context.Entry(collection).State = EntityState.Modified;
				Data.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(collection);
		}

		// GET: UserData/Collections/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Collection collection = Data.Collections.Find(id);
			if (collection == null)
			{
				return HttpNotFound();
			}
			return View(collection);
		}

		// POST: UserData/Collections/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{
			Collection collection = Data.Collections.Find(id);
			Data.Collections.Delete(collection);
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