using System;
using UD22_EJ1.DTO;
using UD22_EJ1.Model;

namespace UD22_EJ1.View
{
    public interface ICliente
    {
        void ActualizarVista(ClienteDto modelo);
        event EventHandler<ClienteDto> ClienteGuardado;
        event EventHandler<ClienteDto> ClienteEliminado;
        event EventHandler<ClienteDto> CargarCliente;
    }
}
