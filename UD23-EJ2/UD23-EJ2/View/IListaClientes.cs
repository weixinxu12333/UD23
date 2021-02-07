using System;
using UD22_EJ1.Model;

namespace UD22_EJ1.View
{
    public interface IListaClientes
    {
        event EventHandler<Modelo> AñadirCliente;
        event EventHandler<Modelo> MostrarCliente;
        event EventHandler<Modelo> LeerClientes;
        void ActualizarVista(Modelo modelo);
    }
}
