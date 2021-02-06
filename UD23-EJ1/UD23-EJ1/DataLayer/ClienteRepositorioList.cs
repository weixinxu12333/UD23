using System;
using System.Collections.Generic;
using System.Text;
using UD22_EJ1.DTO;
using System.Linq;

namespace UD22_EJ1.DataLayer
{
    public class ClienteRepositorioList : IClienteRepositorio
    {
        private readonly List<ClienteDto> clientes = new List<ClienteDto>();

        public ClienteRepositorioList()
        {
            AñadirCliente(new ClienteDto { Nombre = "Wantun", Apellido="Bwana", Direccion="Calle falsa 123", DNI = "12345678J", Fecha = DateTime.Now });
        }

        public void ActualizarCliente(ClienteDto cliente)
        {
            clientes[clientes.FindIndex(c => c.Id == cliente.Id)] = cliente;
        }

        public void AñadirCliente(ClienteDto cliente)
        {
            clientes.Add(new ClienteDto {
                Id = clientes.Count + 1,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Direccion = cliente.Direccion,
                DNI = cliente.DNI,
                Fecha = cliente.Fecha
            });
        }

        public void EliminarCliente(ClienteDto cliente)
        {
            clientes.RemoveAt(clientes.FindIndex(c => c.Id == cliente.Id));
        }

        public ClienteDto ObtenerCliente(ClienteDto cliente)
        {
            return clientes.Find(c => c.Id == cliente.Id);
        }

        public IEnumerable<ClienteDto> ObtenerClientes()
        {
            return clientes;
        }
    }
}
