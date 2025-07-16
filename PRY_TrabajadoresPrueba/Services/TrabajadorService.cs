using PRY_TrabajadoresPrueba.Models.Models;
using PRY_TrabajadoresPrueba.Models.Parameters;
using PRY_TrabajadoresPrueba.Models.Result;
using PRY_TrabajadoresPrueba.Repository;

namespace PRY_TrabajadoresPrueba.Services
{
    public class TrabajadorService
    {
        private readonly TrabajadorRepository _repo;

        public TrabajadorService(TrabajadorRepository repo)
        {
            _repo = repo;
        }

        public List<Sp_Mostrar_Trabajadores> Listar()
        {
            return _repo.ObtenerTrabajadores();
        }

        public string Registrar(TrabajadoresParameters parameters)
        {
            return _repo.RegistrarTrabajador(parameters);
        }

        public string Eliminar(int id_User)
        {
            return _repo.EliminarTrabajador(id_User);
        }

        public List<Sp_Buscar_Trabajador_Id> MostrarTrabajadorId(int id)
        {
            return _repo.MostrarTrabajadorId(id);
        }

        public string Editar(TrabajadorUpdateParameters parameters)
        {
            return _repo.EditarTrabajador(parameters);
        }
    }
}
