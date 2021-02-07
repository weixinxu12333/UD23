using System.Collections.Generic;
using UD22_EJ1.DTO;

namespace UD22_EJ1.DataLayer
{
    public class VideoRepositorioList : IVideoRepositorio
    {
        private readonly List<VideoDto> videos = new List<VideoDto>();

        public void ActualizarVideo(VideoDto video)
        {
            videos[videos.FindIndex(c => c.Id == video.Id)] = video;
        }

        public void AñadirVideo(VideoDto video)
        {
            videos.Add(new VideoDto
            {
                Id = videos.Count + 1,
                Title = video.Title,
                Director = video.Director,
                Cli_id = video.Cli_id
            });
        }

        public void EliminarVideo(VideoDto video)
        {
            videos.RemoveAt(videos.FindIndex(c => c.Id == video.Id));
        }

        public VideoDto ObtenerVideo(VideoDto video)
        {
            return videos.Find(c=> c.Id == video.Id);
        }

        public IEnumerable<VideoDto> ObtenerVideos()
        {
            return videos;
        }

        public IEnumerable<VideoDto> ObtenerVideos(int idCliente)
        {
            return videos.FindAll(c => c.Cli_id == idCliente);
        }
    }
}
