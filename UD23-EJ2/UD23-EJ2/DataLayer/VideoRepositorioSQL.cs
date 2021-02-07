using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using UD22_EJ1.DTO;

namespace UD22_EJ1.DataLayer
{
    public class VideoRepositorioSQL : IVideoRepositorio
    {
        private readonly QueryFactory db;

        public VideoRepositorioSQL(IDbConnection connection)
        {
            db = new QueryFactory(connection, new SqlServerCompiler());
        }

        public void ActualizarVideo(VideoDto video)
        {
            db.Query("dbo.videos").Where("id", video.Id).Update(new
            {
                title = video.Title,
                director = video.Director,
                cli_id = video.Cli_id
            });
        }

        //posible error, cli_id es int, hay q convertir?
        //como conectar entre 2 tablas?
        public void AñadirVideo(VideoDto video)
        {
            db.Query("dbo.videos").Insert(new
            {
                title = video.Title,
                director = video.Director,
                cli_id = video.Cli_id
            });
        }

        public void EliminarVideo(VideoDto video)
        {
            db.Query("dbo.videos").Where("id", video.Id).Delete();
        }

        public VideoDto ObtenerVideo(VideoDto video)
        {
            return db.Query("dbo.videos").Where("id", video.Id).First<VideoDto>();
        }

        public IEnumerable<VideoDto> ObtenerVideos()
        {
            return db.Query("dbo.videos").Get<VideoDto>();
        }

        public IEnumerable<VideoDto> ObtenerVideos(int idCliente)
        {
            return db.Query("dbo.videos").Where("cli_id", idCliente).Get<VideoDto>();
        }
    }
}
