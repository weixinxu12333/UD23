using System;
using UD22_EJ1.Model;

namespace UD22_EJ1
{
    public partial class Agregar : System.Windows.Forms.Form
    {
        public Agregar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            string cadena = "";

            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string direccion = textBox3.Text;
            string dni = textBox4.Text;
            string fecha = dateTimePicker1.Value.ToString("dd-MM-yyyy");

            modelo.ConectarBD();

            cadena = "USE clientes;";
            modelo.Ejecutar(cadena);

            cadena = @"INSERT INTO clientes VALUES (nombre, apellido, direccion, dni)";
            modelo.Ejecutar(cadena);
            
        }
    }
}
