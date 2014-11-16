namespace Streamus.Data
{
	using Microsoft.AspNet.Identity.EntityFramework;
	using Streamus.Data.Migrations;
	using Streamus.Data.Models;
	using System.Data.Entity;

	public partial class StreamusDbContext : IdentityDbContext<User>
	{
		public StreamusDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<StreamusDbContext, Configuration>());
		}

		public virtual DbSet<Collection> Collections { get; set; }

		public virtual DbSet<MediaItem> MediaItems { get; set; }

		public virtual DbSet<MediaItemThumbnail> MediaItemThumbnails { get; set; }

		public virtual DbSet<Playlist> Playlists { get; set; }

		public static StreamusDbContext Create()
		{
			return new StreamusDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Collection>()
				.HasMany(e => e.MediaItems)
				.WithMany(e => e.Collections)
				.Map(m => m.ToTable("CollectionsMediaItems").MapLeftKey("CollectionId").MapRightKey("MediaItemId"));

			modelBuilder.Entity<Collection>()
				.HasMany(e => e.Playlists)
				.WithMany(e => e.Collections)
				.Map(m => m.ToTable("PlaylistsCollections").MapLeftKey("CollectionId").MapRightKey("PlaylistId"));

			modelBuilder.Entity<MediaItem>()
				.HasMany(e => e.Playlists)
				.WithMany(e => e.MediaItems)
				.Map(m => m.ToTable("PlaylistsMediaItems").MapLeftKey("MediaItemId").MapRightKey("PlaylistId"));

			modelBuilder.Entity<MediaItemThumbnail>()
				.Property(e => e.Type)
				.IsUnicode(false);

			modelBuilder.Entity<MediaItemThumbnail>()
				.HasMany(e => e.MediaItems)
				.WithRequired(e => e.Thumbnail)
				.HasForeignKey(e => e.ThumbnailId)
				.WillCascadeOnDelete(false);
		}
	}
}