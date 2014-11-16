namespace Streamus.Data
{
	using System;
	using System.Linq;
	using System.Linq.Expressions;

	public interface IRepository<T> where T : class
	{
		IQueryable<T> All();

		T Find(object id);

		void Add(T entity);

		IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> expression);

		void Update(T entity);

		void Delete(T entity);

		void Delete(object id);

		void Detach(T entity);
	}
}