using System;
using System.Collections.Generic;
using System.Text;
using UD22_EJ1.DTO;


namespace UD22_EJ1.DataLayer
{
    public interface IVideoRepositorio
    {
        public VideoDto ObtenerVideo(VideoDto video);
        public IEnumerable<VideoDto> ObtenerVideos();
        public IEnumerable<VideoDto> ObtenerVideos(int idCliente);
        public void AñadirVideo(VideoDto video);
        public void ActualizarVideo(VideoDto video);
        public void EliminarVideo(VideoDto video);
    }
}
