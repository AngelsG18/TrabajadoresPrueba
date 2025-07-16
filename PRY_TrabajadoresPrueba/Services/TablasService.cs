using PRY_TrabajadoresPrueba.Models.Models;
using PRY_TrabajadoresPrueba.Models.Result;
using PRY_TrabajadoresPrueba.Repository;

namespace PRY_TrabajadoresPrueba.Services
{
    public class TablasService
    {
        private readonly TablasRepository _repo;
        public TablasService(TablasRepository repo)
        {
            _repo = repo;
        }
        public List<TipoDocumento> ListarTipoDocumento() { return _repo.MostrarTipoDocumento(); }
        public List<Departamento> ListarDepartamento() { return _repo.MostrarDepartamentos(); }
        public List<Provincium> ListarProvincia(int id_Depa) { return _repo.MostrarProvincia(id_Depa); }
        public List<Distrito> ListarDistrito(int id_Prov) { return _repo.MostrarDistrito(id_Prov); }

    }
}
