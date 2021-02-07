using System;
using UD22_EJ1.DTO;

namespace UD22_EJ1.View
{
    public interface IVideo
    {
        event EventHandler<VideoDto> GuardarVideo;
        event EventHandler<VideoDto> EliminarVideo;
    }
}
