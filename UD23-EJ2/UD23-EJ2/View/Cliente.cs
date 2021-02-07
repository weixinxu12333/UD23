using System;
using System.Windows.Forms;
using UD22_EJ1.Model;
using System.Linq;
using UD22_EJ1.DTO;
using System.ComponentModel;
using System.Collections.Generic;

namespace UD22_EJ1.View
{
    public partial class Cliente : Form, ICliente
    {
        // Eventos
        public event EventHandler<ClienteDto> ClienteEliminado;
        public event EventHandler<ClienteDto> ClienteGuardado;
        public event EventHandler<ClienteDto> CargarCliente;

        private ClienteDto cliente;

        public Cliente() : this(new ClienteDto()) { }

        public Cliente(ClienteDto cliente)
        {
            InitializeComponent();
            // Agregando Handlers a los componentes
            btnGuardar.Click += BtnGuardar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnAñadirVideo.Click += BtnVideos_Click;
            this.cliente = cliente;
            this.Load += Cliente_Load;
            this.dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
            this.dataGridView1.CellMouseDoubleClick += DataGridView1_CellMouseDoubleClick;
        }

        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sender is DataGridView dg)
            {
                var vId = (int)dg.Rows[e.RowIndex].Cells["Id"].Value;
                Video video = new Video(cliente.Videos.FirstOrDefault(v => v.Id == vId));
                video.GuardarVideo += Video_GuardarVideo;
                video.EliminarVideo += Video_EliminarVideo;
                video.ShowDialog();
            }
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            textBox1.Text = cliente.Nombre;
            textBox2.Text = cliente.Apellido;
            textBox3.Text = cliente.Direccion;
            textBox4.Text = cliente.DNI;
            dateTimePicker1.Value = cliente.Fecha ?? DateTime.Now;
            btnEliminar.Visible = cliente.Id > 0;
            BindVideos();
        }

        private void BindVideos()
        {
            var bindingList = new BindingList<VideoDto>(cliente?.Videos?.ToList() ?? new List<VideoDto>());
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void BtnVideos_Click(object sender, EventArgs e)
        {
            Video video = new Video();
            video.GuardarVideo += Video_GuardarVideo;
            video.EliminarVideo += Video_EliminarVideo;
            video.ShowDialog();
        }

        private void Video_EliminarVideo(object sender, VideoDto e)
        {
            cliente.Videos = cliente.Videos.Where(v => v != e);
            BindVideos();
        }

        private void Video_GuardarVideo(object sender, VideoDto e)
        {
            if(e.Id == 0)
            {
                e.Cli_id = cliente.Id;
                cliente.Videos = cliente.Videos.Concat(new[] { e });
            }
            BindVideos();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            cliente.Nombre = textBox1.Text;
            cliente.Apellido = textBox2.Text;
            cliente.Direccion = textBox3.Text;
            cliente.DNI = textBox4.Text; 
            cliente.Fecha = dateTimePicker1.Value;
            
            ClienteGuardado?.Invoke(this, cliente);
            this.Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ClienteEliminado?.Invoke(this, cliente);
            this.Close();
        }

        public void ActualizarVista(ClienteDto modelo)
        {
            this.cliente = modelo;

            
        }
        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridView1.Columns["Cli_id"].Visible = false;
        }
    }
}
