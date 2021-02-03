using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace UD22_EJ1.Model
{
    class Modelo
    {
        //BD creado a parte, porque no es reutilizable
        //BD crear tabla tmb creado con mano, mismo motivo

        SqlConnection conexion;

        public void ConectarBD()
        {
            try
            {
                conexion = new SqlConnection("server=192.168.1.40; Database=clientes; User id=sa; Password=Aqwerty963.");
                conexion.Open();
                Console.WriteLine("Conectado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DesconectarBD()
        {
            try
            {
                conexion.Close();
                Console.WriteLine("Desconectado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Ejecutar(string cadena)
        {
            try
            {
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                Console.WriteLine("comando ejecutado correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
