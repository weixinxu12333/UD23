using System;
using System.Collections.Generic;
using System.Text;
using UD22_EJ1.DTO;

namespace UD22_EJ1.Model
{
    public class Modelo
    {
        public ClienteDto ClienteActual { get; set; }
        public IEnumerable<ClienteDto> Clientes { get; set; }

    }
}
