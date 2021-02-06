using System;
using UD22_EJ1.DataLayer;
using UD22_EJ1.DTO;
using UD22_EJ1.Model;
using UD22_EJ1.View;

namespace UD22_EJ1.Controller
{
    class Controlador : IControlador
    {
        private readonly ICliente cliente;
        private readonly IClienteRepositorio repositorio;

        public Controlador(ICliente cliente, IClienteRepositorio repositorio)
        {
            this.cliente = cliente;
            this.repositorio = repositorio;

            // Escuchar eventos de la vista
            cliente.ClienteCreado += Cliente_ClienteCreado;
            cliente.ClienteActualizado += Cliente_ClienteActualizado;
            cliente.ClienteEliminado += Cliente_ClienteEliminado;
            cliente.LeerClientes += Cliente_LeerClientes;
            cliente.ClienteSeleccionado += Cliente_ClienteSeleccionado;
        }

        public Modelo Crear(Modelo modelo)
        {
            repositorio.AñadirCliente(modelo.ClienteActual);
            return Leer(modelo);
        }

        public Modelo Leer(Modelo modelo)
        {
            modelo.Clientes = repositorio.ObtenerClientes();
            modelo.ClienteActual = new ClienteDto();
            return modelo;
        }

        public Modelo Actualizar(Modelo modelo)
        {
            repositorio.ActualizarCliente(modelo.ClienteActual);
            return Leer(modelo);
        }

        public Modelo Eliminar(Modelo modelo)
        {
            repositorio.EliminarCliente(modelo.ClienteActual);
            return Leer(modelo);
        }

        public Modelo Seleccionar(Modelo modelo)
        {
            modelo.ClienteActual = repositorio.ObtenerCliente(modelo.ClienteActual);
            return modelo;
        }

        private void Cliente_ClienteCreado(object sender, Modelo e)
        {
            cliente.ActualizarVista(Crear(e));
        }

        private void Cliente_ClienteActualizado(object sender, Modelo e)
        {
            cliente.ActualizarVista(Actualizar(e));
        }

        private void Cliente_ClienteEliminado(object sender, Modelo e)
        {
            cliente.ActualizarVista(Eliminar(e));
        }

        private void Cliente_LeerClientes(object sender, Modelo e)
        {
            cliente.ActualizarVista(Leer(e));
        }

        private void Cliente_ClienteSeleccionado(object sender, Modelo e)
        {
            cliente.ActualizarVista(Seleccionar(e));
        }
    }
}
