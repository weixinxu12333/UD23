using System;
using System.Windows.Forms;
using UD22_EJ1.View;
using UD22_EJ1.Controller;

namespace UD22_EJ1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            Cliente cliente = new Cliente();
            Controlador controlador = new Controlador(cliente);
            cliente.ShowDialog();
            //Application.Run(cliente);


        }
    }
}
