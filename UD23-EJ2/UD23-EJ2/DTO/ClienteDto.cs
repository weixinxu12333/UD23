﻿using System;
using System.Collections.Generic;

namespace UD22_EJ1.DTO
{
    public class ClienteDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Direccion { get; set; }

        public string DNI { get; set; }

        // DateTime no puede ser null. En .NET se tiene que "envolver" con Nullable<> para que pueda serlo.
        // Para escribir menos, DateTime? == Nullable<DateTime>
        public DateTime? Fecha { get; set; }

        public IEnumerable<VideoDto> Videos { get; set; }

    }
}
