namespace Streamus.Web.Areas.Administration.Controllers
{
	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using Kendo.Mvc.Extensions;
	using Kendo.Mvc.UI;
	using Streamus.Common;
	using Streamus.Data;
	using Streamus.Data.Models;
	using Streamus.Web.Areas.Administration.ViewModel;
	using Streamus.Web.Controllers;
	using System;
	using System.Collections;
	using System.Data.Entity;
	using System.Web.Mvc;

	[Authorize(Roles = AppRoles.Admin)]
	public abstract class BaseAdministrationController<TModel, TViewModel> : BaseController
		where TModel : class, IBaseItem
		where TViewModel : BaseViewModel
	{
		protected abstract IRepository<TModel> Items { get; }

		public BaseAdministrationController(IStreamusData data)
			: base(data)
		{
		}

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create([DataSourceRequest]DataSourceRequest request, TViewModel model)
		{
			model.Id = Guid.NewGuid().ToString();
			var dbModel = this.Create(model);
			if (dbModel != null) model.Id = dbModel.Id;
			return this.GridOperation(model, request);
		}

		[HttpPost]
		public ActionResult Update([DataSourceRequest]DataSourceRequest request, TViewModel model)
		{
			this.Update(model, model.Id);
			return this.GridOperation(model, request);
		}

		[HttpPost]
		public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, TViewModel model)
		{
			if (model != null && ModelState.IsValid)
			{
				var item = this.Items.Find(model.Id);
				this.Items.Delete(item);
				this.Data.SaveChanges();
			}

			return this.GridOperation(model, request);
		}

		protected IEnumerable GetData()
		{
			return this.Items
				.All()
				.Project()
				.To<TViewModel>();
		}

		protected TModel GetById(object id)
		{
			return this.Items.Find(id);
		}

		[HttpPost]
		public ActionResult Read([DataSourceRequest]DataSourceRequest request)
		{
			var data = this.GetData()
				.ToDataSourceResult(request);

			return this.Json(data);
		}

		[NonAction]
		protected virtual TModel Create(TViewModel model)
		{
			if (model != null && ModelState.IsValid)
			{
				var dbModel = Mapper.Map<TModel>(model);
				this.ChangeEntityStateAndSave(dbModel, EntityState.Added);
				return dbModel;
			}

			return null;
		}

		[NonAction]
		protected void Update(TViewModel model, object id)
		{
			if (model != null && ModelState.IsValid)
			{
				var dbModel = this.GetById(id);
				Mapper.Map<TViewModel, TModel>(model, dbModel);
				this.ChangeEntityStateAndSave(dbModel, EntityState.Modified);
			}
		}

		protected JsonResult GridOperation(TViewModel model, [DataSourceRequest]DataSourceRequest request)
		{
			return Json(new[] { model }.ToDataSourceResult(request, ModelState));
		}

		private void ChangeEntityStateAndSave(object dbModel, EntityState state)
		{
			var entry = this.Data.Context.Entry(dbModel);
			entry.State = state;
			this.Data.SaveChanges();
		}
	}
}