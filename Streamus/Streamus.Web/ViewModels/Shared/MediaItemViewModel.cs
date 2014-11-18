using Streamus.Data.Models;
using Streamus.Web.Infrastructure.Mapping;

namespace Streamus.Web.ViewModels.Shared
{
	public class MediaItemViewModel : IMapFrom<Google.YouTube.Video>, IMapFrom<MediaItem>, IHaveCustomMappings
	{
		private const string YOUTUBE_LINK = "http://www.youtube.com/watch?v=";

		public string VideoId { get; set; }

		public string Title { get; set; }

		public long Duration { get; set; }

		public string LQImageUrl { get; set; }

		public string MQImageUrl { get; set; }

		public string HQImageUrl { get; set; }

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
				.ForMember(dst => dst.VideoId, opt => opt.MapFrom(src => src.VideoId))
				.ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
				.ForMember(dst => dst.Duration, opt => opt.MapFrom(src => long.Parse(src.Media.Duration.Seconds)))
				.ForMember(dst => dst.LQImageUrl, opt => opt.MapFrom(src => src.Thumbnails[1].Url))
				.ForMember(dst => dst.MQImageUrl, opt => opt.MapFrom(src => src.Thumbnails[2].Url))
				.ForMember(dst => dst.HQImageUrl, opt => opt.MapFrom(src => src.Thumbnails[3].Url));
		}
	}
}