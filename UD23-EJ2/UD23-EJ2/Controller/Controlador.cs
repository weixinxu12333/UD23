using System.Linq;
using UD22_EJ1.DataLayer;
using UD22_EJ1.DTO;
using UD22_EJ1.Model;
using UD22_EJ1.View;

namespace UD22_EJ1.Controller
{
    class Controlador : IControlador
    {
        private readonly IListaClientes listaClientes;
        private readonly IClienteRepositorio clienteRepositorio;
        private readonly IVideoRepositorio videoRepositorio;

        public Controlador(IListaClientes listaClientes, IClienteRepositorio clienteRepositorio, IVideoRepositorio videoRepositorio)
        {
            this.listaClientes = listaClientes;
            this.clienteRepositorio = clienteRepositorio;
            this.videoRepositorio = videoRepositorio;

            // Escuchar eventos de la vista
            listaClientes.AñadirCliente += ListaClientes_AñadirCliente;
            listaClientes.MostrarCliente += ListaClientes_MostrarCliente;
            listaClientes.LeerClientes += ListaClientes_LeerClientes;
        }

        private void ListaClientes_LeerClientes(object sender, Modelo e)
        {
            listaClientes.ActualizarVista(Leer(e));
        }

        private void ListaClientes_MostrarCliente(object sender, Modelo e)
        {
            Seleccionar(e);
        }

        private void ListaClientes_AñadirCliente(object sender, Modelo e)
        {
            var ventanaCliente = new Cliente();
            ventanaCliente.ClienteGuardado += VentanaCliente_ClienteGuardado;
            ventanaCliente.ClienteEliminado += VentanaCliente_ClienteEliminado;
            ventanaCliente.ShowDialog();
        }

        // Cliente
        public Modelo Crear(Modelo modelo)
        {
            clienteRepositorio.AñadirCliente(modelo.ClienteActual);
            foreach (var video in modelo.ClienteActual.Videos)
                videoRepositorio.AñadirVideo(video);
            return Leer(modelo);
        }

        public Modelo Actualizar(Modelo modelo)
        {
            clienteRepositorio.ActualizarCliente(modelo.ClienteActual);
            var videosAntiguos = videoRepositorio.ObtenerVideos(modelo.ClienteActual.Id);
            var videosACrear = modelo.ClienteActual.Videos.Where(v => v.Id == 0);
            var videosAEliminar = videosAntiguos.Except(modelo.ClienteActual.Videos, new VideoDtoComparer());
            var videosAActualizar = modelo.ClienteActual.Videos.Where(v => v.Id != 0);
            foreach (var video in videosACrear)
                videoRepositorio.AñadirVideo(video);
            foreach (var video in videosAActualizar)
                videoRepositorio.ActualizarVideo(video);
            foreach (var video in videosAEliminar)
                videoRepositorio.EliminarVideo(video);
            return Leer(modelo);
        }

        public Modelo Leer(Modelo modelo)
        {
            modelo.Clientes = clienteRepositorio.ObtenerClientes();
            modelo.ClienteActual = new ClienteDto();
            return modelo;
        }

        public Modelo Eliminar(Modelo modelo)
        {
            clienteRepositorio.EliminarCliente(modelo.ClienteActual);
            return Leer(modelo);
        }

        public void Seleccionar(Modelo modelo)
        {
            var cliente = clienteRepositorio.ObtenerCliente(modelo.ClienteActual);
            cliente.Videos = videoRepositorio.ObtenerVideos(cliente.Id);
            var ventanaCliente = new Cliente(cliente);
            ventanaCliente.ClienteGuardado += VentanaCliente_ClienteGuardado;
            ventanaCliente.ClienteEliminado += VentanaCliente_ClienteEliminado;
            ventanaCliente.ShowDialog();
        }

        private void VentanaCliente_ClienteEliminado(object sender, ClienteDto e)
        {
            var modelo = new Modelo { ClienteActual = e };
            listaClientes.ActualizarVista(Eliminar(modelo));
        }

        private void VentanaCliente_ClienteGuardado(object sender, ClienteDto e)
        {
            var modelo = new Modelo { ClienteActual = e };
            if(e.Id > 0)
                listaClientes.ActualizarVista(Actualizar(modelo));
            else
                listaClientes.ActualizarVista(Crear(modelo));
        }
    }
}
