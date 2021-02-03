using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UD22_EJ1.Model;

namespace UD22_EJ1.View
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Modelo modelo = new Modelo();
            modelo.ConectarBD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox1.Text);
            switch (num)
            {
                case 1:
                    Agregar ag = new Agregar();
                    ag.ShowDialog();
                    break;
                case 2:
                    Leer l = new Leer();
                    l.ShowDialog();
                    break;
                case 3:
                    Actualizar ac = new Actualizar();
                    ac.ShowDialog();
                    break;
                case 4:
                    Eliminar el = new Eliminar();
                    el.ShowDialog();
                    break;
                case 5:
                    this.Close();
                    break;
                default:
                    MessageBox.Show("Introduce 1-5");
                    break;
            }
        }
    }
}
