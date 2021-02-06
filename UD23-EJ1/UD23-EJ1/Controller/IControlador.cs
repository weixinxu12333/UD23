using System;
using System.Collections.Generic;
using System.Text;
using UD22_EJ1.Model;

namespace UD22_EJ1.Controller
{
    public interface IControlador
    {
        Modelo Crear(Modelo modelo);
        Modelo Leer(Modelo modelo);
        Modelo Actualizar(Modelo modelo);
        Modelo Eliminar(Modelo modelo);
        Modelo Seleccionar(Modelo modelo);
    }
}
