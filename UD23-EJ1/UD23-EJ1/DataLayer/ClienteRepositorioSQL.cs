using System;
using System.Collections.Generic;
using System.Data;
using UD22_EJ1.DTO;
using SqlKata;
using SqlKata.Execution;
using SqlKata.Compilers;

namespace UD22_EJ1.DataLayer
{
    public class ClienteRepositorioSQL : IClienteRepositorio
    {
        private readonly QueryFactory db;
        public ClienteRepositorioSQL(IDbConnection connection)
        {
            db = new QueryFactory(connection, new SqlServerCompiler());
        }

        public void ActualizarCliente(ClienteDto cliente)
        {
            db.Query("dbo.cliente").Where("id", cliente.Id).Update(new
            {
                nombre = cliente.Nombre,
                apellido = cliente.Apellido,
                dni = cliente.DNI,
                direccion = cliente.Direccion,
                fecha = cliente.Fecha,
            });
        }

        public void AñadirCliente(ClienteDto cliente)
        {
            db.Query("dbo.cliente").Insert(new { 
                nombre = cliente.Nombre,
                apellido = cliente.Apellido,
                dni = cliente.DNI,
                direccion = cliente.Direccion,
                fecha = cliente.Fecha,
            });
        }

        public void EliminarCliente(ClienteDto cliente)
        {
            db.Query("dbo.cliente").Where("id", cliente.Id).Delete();
        }

        public ClienteDto ObtenerCliente(ClienteDto cliente)
        {
            return db.Query("dbo.cliente").Where("id", cliente.Id).First<ClienteDto>();
        }

        public IEnumerable<ClienteDto> ObtenerClientes()
        {
            return db.Query("dbo.cliente").Get<ClienteDto>();
        }
    }
}
