using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UD22_EJ1.DTO;
using UD22_EJ1.Model;

namespace UD22_EJ1.View
{
    public partial class Video : Form, IVideo
    {
        public event EventHandler<VideoDto> GuardarVideo;
        public event EventHandler<VideoDto> EliminarVideo;

        private VideoDto video;

        public Video() : this(new VideoDto()) { }

        public Video(VideoDto video)
        {
            InitializeComponent();
            // Agregando Handlers a los componentes
            btnAgregar.Click += BtnAgregar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            this.Load += Video_Load;
            this.video = video;
        }

        private void Video_Load(object sender, EventArgs e)
        {
            btnEliminar.Visible = video.Id > 0;
            textBox1.Text = video.Title;
            textBox2.Text = video.Director;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            video.Title = textBox1.Text;
            video.Director = textBox2.Text;

            GuardarVideo?.Invoke(this, video);
            Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            EliminarVideo?.Invoke(this, video);
            Close();
        }
    }
}
