namespace Streamus.Web.ViewModels.Shared
{
	using Streamus.Data.Models;
	using Streamus.Web.Infrastructure.Mapping;
	using System.ComponentModel.DataAnnotations;

	public class MediaItemViewModel : BaseViewModel, IMapFrom<Google.YouTube.Video>, IMapFrom<MediaItem>, IHaveCustomMappings
	{
		private const string YOUTUBE_LINK = "http://www.youtube.com/watch?v=";

		[Required]
		[UIHint("String")]
		public string VideoId { get; set; }

		[Required]
		[UIHint("String")]
		public string Title { get; set; }

		[Required]
		public long Duration { get; set; }

		[Required]
		[UIHint("ImageUrl")]
		public string MQImageUrl { get; set; }

		[Required]
		[UIHint("ImageUrl")]
		public string HQImageUrl { get; set; }

		[UIHint("String")]
		public string VideoUrl
		{
			get
			{
				return YOUTUBE_LINK + this.VideoId;
			}
		}

		public void CreateMappings(AutoMapper.IConfiguration configuration)
		{
			configuration.CreateMap<Google.YouTube.Video, MediaItemViewModel>()
				.ForMember(dst => dst.Id, opt => opt.Ignore())
				.ForMember(dst => dst.VideoId, opt => opt.MapFrom(src => src.VideoId))
				.ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
				.ForMember(dst => dst.Duration, opt => opt.MapFrom(src => long.Parse(src.Media.Duration.Seconds)))
				.ForMember(dst => dst.MQImageUrl, opt => opt.MapFrom(src => src.Thumbnails[1].Url))
				.ForMember(dst => dst.HQImageUrl, opt => opt.MapFrom(src => src.Thumbnails[2].Url));
		}
	}
}