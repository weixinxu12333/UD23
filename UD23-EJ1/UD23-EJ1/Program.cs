using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.SqlClient;
using UD22_EJ1.Controller;
using UD22_EJ1.DataLayer;
using UD22_EJ1.View;

namespace UD22_EJ1
{
    public class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Cliente cliente = new Cliente();

            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables();
            var config = configBuilder.Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config);
            services.AddSingleton<ICliente>(cliente);
            services.AddSingleton<IDbConnection>(new SqlConnection(config.GetConnectionString("default")));
            services.AddSingleton<IClienteRepositorio, ClienteRepositorioSQL>();
            services.AddSingleton<IControlador, Controlador>();
            var sp = services.BuildServiceProvider();

            IControlador controlador = sp.GetService<IControlador>();
            cliente.ShowDialog();

        }
    }
}
