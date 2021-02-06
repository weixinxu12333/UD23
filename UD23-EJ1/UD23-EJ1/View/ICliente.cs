using System;
using UD22_EJ1.Model;

namespace UD22_EJ1.View
{
    public interface ICliente
    {
        void ActualizarVista(Modelo modelo);
        event EventHandler<Modelo> ClienteCreado;
        event EventHandler<Modelo> ClienteSeleccionado;
        event EventHandler<Modelo> ClienteActualizado;
        event EventHandler<Modelo> ClienteEliminado;
        event EventHandler<Modelo> LeerClientes;
    }
}
