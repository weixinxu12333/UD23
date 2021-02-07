using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UD22_EJ1.DTO;
using UD22_EJ1.Model;

namespace UD22_EJ1.View
{
    public partial class ListaClientes : Form, IListaClientes
    {

        private Modelo modelo = new Modelo();
        public ListaClientes()
        {
            InitializeComponent();
            this.Load += ListaClientes_Load;
            this.dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
            this.dataGridView1.CellMouseDoubleClick += DataGridView1_CellMouseDoubleClick;
            this.btnAgregar.Click += BtnAgregar_Click;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            AñadirCliente?.Invoke(this, modelo);
        }

        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(sender is DataGridView dg)
            {
                modelo.ClienteActual = new ClienteDto { Id = (int)dg.Rows[e.RowIndex].Cells["Id"].Value };
                MostrarCliente?.Invoke(this, modelo);
            }
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridView1.Columns["Videos"].Visible = false;
        }

        private void ListaClientes_Load(object sender, EventArgs e)
        {
            LeerClientes?.Invoke(this, modelo);
        }

        public event EventHandler<Modelo> AñadirCliente;
        public event EventHandler<Modelo> MostrarCliente;
        public event EventHandler<Modelo> LeerClientes;

        public void ActualizarVista(Modelo modelo)
        {
            var bindingList = new BindingList<ClienteDto>(modelo.Clientes.ToList());
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }
    }
}
