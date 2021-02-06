using System;
using System.Windows.Forms;
using UD22_EJ1.Model;
using System.Linq;
using UD22_EJ1.DTO;

namespace UD22_EJ1.View
{
    public partial class Cliente : Form, ICliente
    {
        // Eventos
        public event EventHandler<Modelo> ClienteCreado;
        public event EventHandler<Modelo> ClienteSeleccionado;
        public event EventHandler<Modelo> ClienteActualizado;
        public event EventHandler<Modelo> ClienteEliminado;
        public event EventHandler<Modelo> LeerClientes;

        private Modelo modelo = new Modelo();

        public Cliente()
        {
            InitializeComponent();
            // Agregando Handlers a los componentes
            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            listView1.MouseDoubleClick += ListView1_MouseDoubleClick;
            this.Load += Cliente_Load;
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(sender is ListView lv)
            {
                if(lv.SelectedItems.Count > 0 && lv.SelectedItems[0].Name.StartsWith("cliente"))
                {
                    modelo.ClienteActual = new ClienteDto { Id = int.Parse(lv.SelectedItems[0].Name.Substring(7)) };
                    ClienteSeleccionado?.Invoke(this, modelo);
                }
            }
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            //si no es null
            LeerClientes?.Invoke(this, modelo);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            modelo.ClienteActual = new ClienteDto {
                Nombre = textBox1.Text,
                Apellido = textBox2.Text,
                Direccion = textBox3.Text,
                DNI = textBox4.Text, 
                Fecha = dateTimePicker1.Value
            };
            
            ClienteCreado?.Invoke(this, modelo);
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            modelo.ClienteActual.Nombre = textBox1.Text;
            modelo.ClienteActual.Apellido = textBox2.Text;
            modelo.ClienteActual.Direccion = textBox3.Text;
            modelo.ClienteActual.DNI = textBox4.Text;
            modelo.ClienteActual.Fecha = dateTimePicker1.Value;
            ClienteActualizado?.Invoke(this, modelo);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ClienteEliminado?.Invoke(this, modelo);
        }

        public void ActualizarVista(Modelo modelo)
        {
            this.modelo = modelo;
            textBox1.Text = modelo.ClienteActual.Nombre;
            textBox2.Text = modelo.ClienteActual.Apellido;
            textBox3.Text = modelo.ClienteActual.Direccion;
            textBox4.Text = modelo.ClienteActual.DNI;
            // ?? = si es null, poner fecha de ahora
            //dateTimePicker1.Value = (modelo.ClienteActual.Fecha == null ? DateTime.Now : modelo.ClienteActual.Fecha.Value);
            dateTimePicker1.Value = modelo.ClienteActual.Fecha ?? DateTime.Now;

            btnActualizar.Enabled = modelo.ClienteActual.Id > 0;
            btnEliminar.Enabled = modelo.ClienteActual.Id > 0;
            
            listView1.Items.Clear();
            listView1.Items.AddRange(modelo.Clientes.Select(c => new ListViewItem { Name="cliente" + c.Id, Text = $"{c.Nombre} {c.Apellido} # {c.DNI}"}).ToArray());
         }
    }
}
