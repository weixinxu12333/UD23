using System.Collections.Generic;
using UD22_EJ1.DTO;

namespace UD22_EJ1.DataLayer
{
    public interface IClienteRepositorio
    {
        public ClienteDto ObtenerCliente(ClienteDto cliente);
        public IEnumerable<ClienteDto> ObtenerClientes();
        public void AñadirCliente(ClienteDto cliente);
        public void ActualizarCliente(ClienteDto cliente);
        public void EliminarCliente(ClienteDto cliente);
    }
}
