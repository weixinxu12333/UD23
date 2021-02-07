using UD22_EJ1.Model;

namespace UD22_EJ1.Controller
{
    public interface IControlador
    {
        //cliente
        Modelo Crear(Modelo modelo);
        Modelo Leer(Modelo modelo);
        Modelo Actualizar(Modelo modelo);
        Modelo Eliminar(Modelo modelo);
        void Seleccionar(Modelo modelo);
    }
}
