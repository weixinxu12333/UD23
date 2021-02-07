using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UD22_EJ1.DTO
{
    public class VideoDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director  { get; set; }

        public int Cli_id { get; set; }
    }

    public class VideoDtoComparer : IEqualityComparer<VideoDto>
    {
        public bool Equals([AllowNull] VideoDto x, [AllowNull] VideoDto y)
        {
            return x != null && y != null 
                && x is VideoDto xv && y is VideoDto yv
                && xv.Id == yv.Id 
                && xv.Id != 0;
        }

        public int GetHashCode([DisallowNull] VideoDto obj)
        {
            return obj.Id;
        }
    }
}
