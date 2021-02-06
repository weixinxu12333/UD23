using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

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
                conexion = new SqlConnection("");
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

        public string Leer(string cadena)
        {
            try
            {
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(registros);

                foreach (DataRow dr in dt.Rows)
                {
                    int i = 0;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        return dr[i].ToString();
                        i++;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return "Error "+e;
            }
        }

        ////public string AgregarCliente(string nombre, string apellido, string direccion, string dni, string fecha)
        ////{
        ////    string cadena = "INSERT INTO cliente VALUES(" + nombre + "," + apellido + "," + direccion + "," + dni + "," + fecha + ");";
        ////    return cadena;
        ////}

        //public string ActualizarCliente(string nombre, string apellido, string direccion, string dni, string fecha)
        //{
        //    string cadena = "UPDATE cliente SET nombre =" + nombre + ",apellido=" + apellido + ",direccion=" + direccion + ",dni=" + dni + ", fecha=" + fecha + ";";
        //    return cadena;
        //}

        //public void EliminarCliente(string dni)
        //{
        //    Modelo modelo = new Modelo();
        //    modelo.ConectarBD();
        //    string cadena = "DELETE FROM cliente WHERE dni=" + dni + ";";
        //    modelo.Ejecutar(cadena);
        //    modelo.DesconectarBD();
        //}

        //public void VerCliente(string dni)
        //{
        //    Modelo modelo = new Modelo();
        //    modelo.ConectarBD();
        //    string cadena = "SELECT * FROM cliente WHERE dni=" + dni + ";";
        //    modelo.Ejecutar(cadena);
        //    modelo.DesconectarBD();
        //}

        //public void VerClienteTodos()
        //{
        //    Modelo modelo = new Modelo();
        //    modelo.ConectarBD();
        //    string cadena = "SELECT * FROM cliente;";
        //    modelo.Ejecutar(cadena);
        //    modelo.DesconectarBD();
        //}
    }
}
