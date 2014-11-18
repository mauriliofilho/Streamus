namespace Streamus.Data
{
	using Streamus.Data.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;

	public class StreamusData : IStreamusData
	{
		private readonly DbContext context;

		private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

		public StreamusData(DbContext context)
		{
			this.context = context;
		}

		public IRepository<Playlist> Playlists
		{
			get
			{
				return this.GetRepository<Playlist>();
			}
		}

		public IRepository<Collection> Collections
		{
			get
			{
				return this.GetRepository<Collection>();
			}
		}

		public IRepository<MediaItem> MediaItems
		{
			get
			{
				return this.GetRepository<MediaItem>();
			}
		}

		public IRepository<User> Users
		{
			get
			{
				return this.GetRepository<User>();
			}
		}

		public DbContext Context
		{
			get
			{
				return this.context;
			}
		}

		/// <summary>
		/// Saves all changes made in this context to the underlying database.
		/// </summary>
		/// <returns>
		/// The number of objects written to the underlying database.
		/// </returns>
		/// <exception cref="System.InvalidOperationException">Thrown if the context has been disposed.</exception>
		public int SaveChanges()
		{
			return this.context.SaveChanges();
		}

		public void Dispose()
		{
			this.Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.context != null)
				{
					this.context.Dispose();
				}
			}
		}

		private IRepository<T> GetRepository<T>() where T : class
		{
			if (!this.repositories.ContainsKey(typeof(T)))
			{
				var type = typeof(GenericRepository<T>);

				this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
			}

			return (IRepository<T>)this.repositories[typeof(T)];
		}
	}
}