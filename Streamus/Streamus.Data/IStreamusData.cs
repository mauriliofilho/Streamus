namespace Streamus.Data
{
	using Streamus.Data.Models;
	using System.Data.Entity;

	public interface IStreamusData
	{
		DbContext Context { get; }

		IRepository<Playlist> Playlists { get; }

		IRepository<Collection> Collections { get; }

		IRepository<MediaItem> MediaItems { get; }

		IRepository<MediaItemThumbnail> MediaItemThumbnails { get; }

		IRepository<User> Users { get; }

		void Dispose();

		int SaveChanges();
	}
}