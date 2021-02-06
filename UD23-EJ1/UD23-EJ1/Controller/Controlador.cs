using System;
using System.Data;
using System.Windows.Forms;
using UD22_EJ1.Model;
using UD22_EJ1.View;

namespace UD22_EJ1.Controller
{
    class Controlador
    {
        DataTable datos = new DataTable("Customers");

        public Controlador(Cliente cliente)
        {
            string nombre = cliente.textBox1.Text;
            string apellido = cliente.textBox2.Text;
            string direccion = cliente.textBox3.Text;
            string dni = cliente.textBox4.Text;
            string fecha = cliente.dateTimePicker1.Value.ToString("dd-MM-yyyy");

            cliente.btnAgregar.Click += (sender, EventArgs) =>
            {
                BtnAgregar_Click(sender, EventArgs, nombre, apellido, direccion, dni, fecha);
                MessageBox.Show(nombre);
            };

            cliente.btnActualizar.Click += (sender, EventArgs) =>
            {
                BtnActualizar_Click(sender, EventArgs, nombre, apellido, direccion, dni, fecha);
                MessageBox.Show(nombre);
            };

            cliente.btnEliminar.Click += (sender, EventArgs) =>
            {
                BtnEliminar_Click(sender, EventArgs, dni);
                MessageBox.Show(dni);
            };

            cliente.btnVer.Click += (sender, EventArgs) =>
            { 
                BtnVer_Click(sender, EventArgs, dni, cliente);
                MessageBox.Show(dni);
            };

            cliente.btnVerTodo.Click += (sender, EventArgs) =>
            {
                BtnVerTodo_Click(sender, EventArgs);
                
            };
        }

        private void BtnAgregar_Click(object sender, EventArgs e, string nombre, string apellido, string direccion, string dni, string fecha)
        {
            Modelo modelo = new Modelo();
            modelo.ConectarBD();
            string cadena = "USE clientes;";
            //modelo.Ejecutar(cadena);
            cadena = "INSERT INTO cliente VALUES(" + nombre + "," + apellido + "," + direccion + "," + dni + "," + fecha + ");";
            //MessageBox.Show(cadena);
            //modelo.Ejecutar(cadena);
            modelo.DesconectarBD();
        }

        private void BtnActualizar_Click(object sender, EventArgs e, string nombre, string apellido, string direccion, string dni, string fecha)
        {
            Modelo modelo = new Modelo();
            modelo.ConectarBD();
            string cadena = "USE clientes;";
            //modelo.Ejecutar(cadena);
            cadena = "UPDATE cliente SET nombre =" + nombre + ",apellido=" + apellido + ",direccion=" + direccion + ",dni=" + dni + ", fecha=" + fecha + " WHERE dni=" + dni + ";";
            //MessageBox.Show(cadena);
            //modelo.Ejecutar(cadena);
            modelo.DesconectarBD();
        }

        private void BtnEliminar_Click(object sender, EventArgs e, string dni)
        {
            Modelo modelo = new Modelo();
            modelo.ConectarBD();
            string cadena = "USE clientes;";
            //modelo.Ejecutar(cadena);
            cadena = "DELETE FROM cliente WHERE dni=" + dni + ";";
            //MessageBox.Show(cadena);
            //modelo.Ejecutar(cadena);
            modelo.DesconectarBD();
        }

        private void BtnVer_Click(object sender, EventArgs e, string dni, Cliente cliente)
        {
            Modelo modelo = new Modelo();
            modelo.ConectarBD();
            string cadena = "USE clientes;";
            //modelo.Ejecutar(cadena);
            cadena = "SELECT * FROM cliente WHERE dni=" + dni + ";";
            //MessageBox.Show(cadena);
            //modelo.Ejecutar(cadena);
            datos = modelo.Leer(cadena);

            cliente.dataGridView1.DataSource = datos;

            modelo.DesconectarBD();

            
        }

        private void BtnVerTodo_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.ConectarBD();
            string cadena = "USE clientes;";
            //modelo.Ejecutar(cadena);
            cadena = "SELECT * FROM cliente;";
            //MessageBox.Show(cadena);
            //modelo.Ejecutar(cadena);
            modelo.DesconectarBD();

            modelo.Leer(cadena);
        }
    }
}
